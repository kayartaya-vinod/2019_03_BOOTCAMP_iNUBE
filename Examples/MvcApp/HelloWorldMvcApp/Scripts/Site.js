function validateEmployeeForm() {

    var errorMessages = [];

    var empId = $("#emp_id").val().trim();

    // in a boolean context, following are considered as false:
    // 0, empty string, false, null, undefined
    if (!empId) {
        errorMessages.push("Id must be entered");
    }
    else if (isNaN(empId)) {
        errorMessages.push("Id must be a numeric value")
    }
    else if (empId <= 0) {
        errorMessages.push("Id must be > 0");
    }

    var empName = $("#emp_name").val().trim();

    if (!empName) {
        errorMessages.push("Employee name is required!");
    }
    else if (empName.length < 3 || empName.length > 25) {
        errorMessages.push("Name must be between 3 to 25 letters");
    }

    if ($("input[type=radio]:checked").length == 0) {
        errorMessages.push("Please choose gender");
    }

    if (errorMessages.length > 0) {
        // some validation errors exist
        // $("ul") --> queries for all "ul" elements
        // $("<ul>") --> creates a new DOM element called "ul"
        var errList = $("<ul>");

        //var errorItems = errorMessages.map(em=> $("<li>").html(em) );
        //errList.html(errorItems);

        for (var i = 0; i < errorMessages.length; i++) {
            $("<li>").html(errorMessages[i]).appendTo(errList);
            //var errItem = $("<li>");
            //errItem.html(errorMessages[i]);
            //errList.append(errItem);
        }
        $("div#errMsgs").html(errList);
        return false;
    }


    return true;
}

function confirmAndDelete(id, btn) {
    if (!confirm("Are you sure you want to delete this permanantly?")) {
        return;
    }

    $.ajax({
        url: "/employee/delete/" + id,
        success: function (resp) {
            $(btn).parent("td").parent("tr").remove();
        }
    });
}