$(document).ready(function () {
    /**
* Initialize with current year and date. Returns reference to plugin object.
*/
    var jfcalplugin = $("#mycal").jFrontierCal({
        date: new Date(),
        agendaClickCallback: myAgendaClickHandler,
        applyAgendaTooltipCallback: myApplyTooltip,
        dragAndDropEnabled: false
    }).data("plugin");

    if (jfcalplugin) {
        jfcalplugin.setAspectRatio("#mycal", 0.5);

        /**
         * Get concert data to populate database
         */
        $.ajax({
            data: '{}',
            dataType: "json",
            type: "POST",
            url: "/Browse/ViewConcerts", 
            success: function (data) {
                //alert(data[0].Description);
                for (var i = 0; i < data.length; i++) {
                    jfcalplugin.addAgendaItem(
                        "#mycal",
                        data[i].Name,
                        new Date(2015, i, 15, 20, 0, 0, 0),
                        new Date(2015, i, 15, 23, 59, 59, 999),
                        false,
                        {
                            //Venue: data[0].Host.VenueName,
                            Time: data[i].Time,
                            Description: data[i].Description
                        },
                        {
                            backgroundColor: "#AA00FF",
                            foregroundColor: "#FFFFFF"
                        }
                    );
                }
            },
            error: function (result) {
                alert(result.responseText);
            }
        });

    /**
	 * Initialize display event form.
	 */
        $("#display-event-form").dialog({
            autoOpen: false,
            height: 400,
            width: 400,
            modal: false,
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                },
            },
            open: function (event, ui) {
                if (clickAgendaItem != null) {
                    var title = clickAgendaItem.title;
                    var startDate = clickAgendaItem.startDate;
                    var endDate = clickAgendaItem.endDate;
                    var allDay = clickAgendaItem.allDay;
                    var data = clickAgendaItem.data;
                    // in our example add agenda modal form we put some fake data in the agenda data. we can retrieve it here.
                    $("#display-event-form").append(
                        "<br><b>" + title + "</b><br><br>"
                    );
                    if (allDay) {
                        $("#display-event-form").append(
                            "(All day event)<br><br>"
                        );
                    } else {
                        $("#display-event-form").append(
                            "<b>Starts:</b> " + startDate + "<br>" +
                            "<b>Ends:</b> " + endDate + "<br><br>"
                        );
                    }
                    for (var propertyName in data) {
                        $("#display-event-form").append("<b>" + propertyName + ":</b> " + data[propertyName] + "<br>");
                    }
                }
            },
            close: function () {
                // clear agenda data
                $("#display-event-form").html("");
            }
        });

        /**
         * Initialize jquery ui datepicker. set date format to yyyy-mm-dd for easy parsing
         */
        $("#dateSelect").datepicker({
            showOtherMonths: true,
            selectOtherMonths: true,
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd'
        });

        /**
         * Set datepicker to current date
         */
        $("#dateSelect").datepicker('setDate', new Date());
        /**
         * Use reference to plugin object to a specific year/month
         */
        $("#dateSelect").bind('change', function () {
            var selectedDate = $("#dateSelect").val();
            var dtArray = selectedDate.split("-");
            var year = dtArray[0];
            // jquery datepicker months start at 1 (1=January)		
            var month = dtArray[1];
            // strip any preceeding 0's		
            month = month.replace(/^[0]+/g, "")
            var day = dtArray[2];
            // plugin uses 0-based months so we subtrac 1
            jfcalplugin.showMonth("#mycal", year, parseInt(month - 1).toString());
        });

        /**
         * Initialize previous month button
         */
        $("#BtnPreviousMonth").button();
        $("#BtnPreviousMonth").click(function () {
            jfcalplugin.showPreviousMonth("#mycal");
            // update the jqeury datepicker value
            var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
            var cyear = calDate.getFullYear();
            // Date month 0-based (0=January)
            var cmonth = calDate.getMonth();
            var cday = calDate.getDate();
            // jquery datepicker month starts at 1 (1=January) so we add 1
            $("#dateSelect").datepicker("setDate", cyear + "-" + (cmonth + 1) + "-" + cday);
            return false;
        });
        /**
         * Initialize next month button
         */
        $("#BtnNextMonth").button();
        $("#BtnNextMonth").click(function () {
            jfcalplugin.showNextMonth("#mycal");
            // update the jqeury datepicker value
            var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
            var cyear = calDate.getFullYear();
            // Date month 0-based (0=January)
            var cmonth = calDate.getMonth();
            var cday = calDate.getDate();
            // jquery datepicker month starts at 1 (1=January) so we add 1
            $("#dateSelect").datepicker("setDate", cyear + "-" + (cmonth + 1) + "-" + cday);
            return false;
        });
    }

    /**
     * Shows a tooltip view when hovering over an event
     */
    function myApplyTooltip(divElm, agendaItem) {

        // Destroy currrent tooltip if present
        if (divElm.data("qtip")) {
            divElm.qtip("destroy");
        }

        var displayData = "";

        var title = agendaItem.title;
        var startDate = agendaItem.startDate;
        var endDate = agendaItem.endDate;
        var allDay = agendaItem.allDay;
        var data = agendaItem.data;
        displayData += "<br><b>" + title + "</b><br><br>";
        if (allDay) {
            displayData += "(All day event)<br><br>";
        } else {
            displayData += "<b>Starts:</b> " + startDate + "<br>" + "<b>Ends:</b> " + endDate + "<br><br>";
        }
        for (var propertyName in data) {
            displayData += "<b>" + propertyName + ":</b> " + data[propertyName] + "<br>"
        }
        // apply tooltip
        divElm.qtip({
            content: displayData,
            position: {
                corner: {
                    tooltip: "bottomMiddle",
                    target: "topMiddle"
                },
                adjust: {
                    mouse: true,
                    x: 0,
                    y: -15
                },
                target: "mouse"
            },
            show: {
                when: {
                    event: 'mouseover'
                }
            },
            style: {
                border: {
                    width: 5,
                    radius: 10
                },
                padding: 10,
                textAlign: "left",
                tip: true,
                name: "dark"
            }
        });

    };

    /**
	 * Called when user clicks and agenda item
	 * use reference to plugin object to edit agenda item
	 */
    function myAgendaClickHandler(eventObj) {
        // Get ID of the agenda item from the event object
        var agendaId = eventObj.data.agendaId;
        // pull agenda item from calendar
        var agendaItem = jfcalplugin.getAgendaItemById("#mycal", agendaId);
        clickAgendaItem = agendaItem;
        $("#display-event-form").dialog('open');
    };

});