//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Student/Index",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: JSON,
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID                  + '</td>';
                html += '<td>' + item.LastName            + '</td>';
                html += '<td>' + item.FirstMidName        + '</td>';
                html += '<td>' + item.EnrollmentDate      + '</td>';
                html += '<td>' + item.CNICBform           + '</td>';
                html += '<td>' + item.FatherName          + '</td>';
                html += '<td>' + item.FatherOccupation    + '</td>';
                html += '<td>' + item.Gender              + '</td>';
                html += '<td>' + item.Islam               + '</td>';
                html += '<td>' + item.BloodGroup          + '</td>';
                html += '<td>' + item.MobileNo            + '</td>';
                html += '<td>' + item.EmailAddress        + '</td>';
                html += '<td>' + item.Provice             + '</td>';
                html += '<td>' + item.PermanentAddress    + '</td>';
                html += '<td>' + item.PostalAddress       + '</td>';
                html += '<td>' + item.Photo               + '</td>';
                html += '<td>' + item.FatherCNIC          + '</td>';
                html += '<td>' + item.FamilyMonthlyIncome + '</td>';
                html += '<td>' + item.DateOfBirth         + '</td>';
                html += '<td>' + item.HafizEQuran         + '</td>';
                html += '<td>' + item.MaritalStatus       + '</td>';
                html += '<td>' + item.GuardianContactNo   + '</td>';
                html += '<td>' + item.Nationality         + '</td>';
                html += '<td>' + item.DomicileDistrict    + '</td>';
                html += '<td>' + item.CreateDate          + '</td>';
                html += '<td>' + item.UpdateDate          + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.ID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage, xhr, ajaxOptions, thrownError) {
            alert(errormessage.responseText);
            alert(xhr.status);
            alert(thrownError);
        }
    });
}

//Add Data Function   
function Add() {
    $('#myModal').modal('Show');
    var res = validate();
    if (res == false) {
        return false;
    }
    var studentObject = {
        ID                 : $('#stdID                 ').val(),
        LastName           : $('#stdLastName           ').val(),
        FirstMidName       : $('#stdFirstMidName       ').val(),
        EnrollmentDate     : $('#stdEnrollmentDate     ').val(),
        CNICBform          : $('#stdCNICBform          ').val(),
        FatherName         : $('#stdFatherName         ').val(),
        FatherOccupation   : $('#stdFatherOccupation   ').val(),
        Gender             : $('#stdGender             ').val(),
        Islam              : $('#stdIslam              ').val(),
        BloodGroup         : $('#stdBloodGroup         ').val(),
        MobileNo           : $('#stdMobileNo           ').val(),
        EmailAddress       : $('#stdEmailAddress       ').val(),
        Provice            : $('#stdProvice            ').val(),
        PermanentAddress   : $('#stdPermanentAddress   ').val(),
        PostalAddress      : $('#stdPostalAddress      ').val(),
        Photo              : $('#stdPhoto              ').val(),
        FatherCNIC         : $('#stdFatherCNIC         ').val(),
        FamilyMonthlyIncome: $('#stdFamilyMonthlyIncome').val(),
        DateOfBirth        : $('#stdDateOfBirth        ').val(),
        HafizEQuran        : $('#stdHafizEQuran        ').val(),
        MaritalStatus      : $('#stdMaritalStatus      ').val(),
        GuardianContactNo  : $('#stdGuardianContactNo  ').val(),
        Nationality        : $('#stdNationality        ').val(),
        DomicileDistrict   : $('#stdDomicileDistrict   ').val(),
        CreateDate         : $('#stdCreateDate         ').val(),
        UpdateDate         : $('#stdUpdateDate         ').val(),
    };

    $.ajax({
        url: "/Student/Create",
        data: JSON.stringify(studentObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(ID) {
    $('#stdLastName           ').css('border-color', 'lightgrey');
    $('#stdFirstMidName       ').css('border-color', 'lightgrey');
    $('#stdEnrollmentDate     ').css('border-color', 'lightgrey');
    $('#stdCNICBform          ').css('border-color', 'lightgrey');
    $('#stdFatherName         ').css('border-color', 'lightgrey');
    $('#stdFatherOccupation   ').css('border-color', 'lightgrey');
    $('#stdGender             ').css('border-color', 'lightgrey');
    $('#stdIslam              ').css('border-color', 'lightgrey');
    $('#stdBloodGroup         ').css('border-color', 'lightgrey');
    $('#stdMobileNo           ').css('border-color', 'lightgrey');
    $('#stdEmailAddress       ').css('border-color', 'lightgrey');
    $('#stdProvice            ').css('border-color', 'lightgrey');
    $('#stdPermanentAddress   ').css('border-color', 'lightgrey');
    $('#stdPostalAddress      ').css('border-color', 'lightgrey');
    $('#stdPhoto              ').css('border-color', 'lightgrey');
    $('#stdFatherCNIC         ').css('border-color', 'lightgrey');
    $('#stdFamilyMonthlyIncome').css('border-color', 'lightgrey');
    $('#stdDateOfBirth        ').css('border-color', 'lightgrey');
    $('#stdHafizEQuran        ').css('border-color', 'lightgrey');
    $('#stdMaritalStatus      ').css('border-color', 'lightgrey');
    $('#stdGuardianContactNo  ').css('border-color', 'lightgrey');
    $('#stdNationality        ').css('border-color', 'lightgrey');
    $('#stdDomicileDistrict   ').css('border-color', 'lightgrey');
    $('#stdCreateDate         ').css('border-color', 'lightgrey');
    $('#ajstdUpdateDate       ').css('border-color', 'lightgrey');
    $.ajax({
    url: "/Student/getbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#stdID                 ').val(result.ID);
            $('#stdLastName           ').val(result.LastName);
            $('#stdFirstMidName       ').val(result.FirstMidName);
            $('#stdEnrollmentDate     ').val(result.EnrollmentDate);
            $('#stdCNICBform          ').val(result.CNICBform);
            $('#stdFatherName         ').val(result.FatherName);
            $('#stdFatherOccupation   ').val(result.FatherOccupation);
            $('#stdGender             ').val(result.Gender);
            $('#stdIslam              ').val(result.Islam);
            $('#stdBloodGroup         ').val(result.BloodGroup);
            $('#stdMobileNo           ').val(result.MobileNo);
            $('#stdEmailAddress       ').val(result.EmailAddress);
            $('#stdProvice            ').val(result.Provice);
            $('#stdPermanentAddress   ').val(result.PermanentAddress);
            $('#stdPostalAddress      ').val(result.PostalAddress);
            $('#stdPhoto              ').val(result.Photo);
            $('#stdFatherCNIC         ').val(result.FatherCNIC);
            $('#stdFamilyMonthlyIncome').val(result.FamilyMonthlyIncome);
            $('#stdDateOfBirth        ').val(result.DateOfBirth);
            $('#stdHafizEQuran        ').val(result.HafizEQuran);
            $('#stdMaritalStatus      ').val(result.MaritalStatus);
            $('#stdGuardianContactNo  ').val(result.GuardianContactNo);
            $('#stdNationality        ').val(result.Nationality);
            $('#stdDomicileDistrict   ').val(result.DomicileDistrict);
            $('#stdCreateDate         ').val(result.CreateDate);
            $('#stdUpdateDate         ').val(result.UpdateDate);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var studentobject = {
        ID                 : $('#stdID                   ').val(),
        LastName           : $('#stdLastName             ').val(),
        FirstMidName       : $('#stdFirstMidName         ').val(),
        EnrollmentDate     : $('#stdEnrollmentDate       ').val(),
        CNICBform          : $('#stdCNICBform            ').val(),
        FatherName         : $('#stdFatherName           ').val(),
        FatherOccupation   : $('#stdFatherOccupation     ').val(),
        Gender             : $('#stdGender               ').val(),
        Islam              : $('#stdIslam                ').val(),
        BloodGroup         : $('#stdBloodGroup           ').val(),
        MobileNo           : $('#stdMobileNo             ').val(),
        EmailAddress       : $('#stdEmailAddress         ').val(),
        Provice            : $('#stdProvice              ').val(),
        PermanentAddress   : $('#stdPermanentAddress     ').val(),
        PostalAddress      : $('#stdPostalAddress        ').val(),
        Photo              : $('#stdPhoto                ').val(),
        FatherCNIC         : $('#stdFatherCNIC           ').val(),
        FamilyMonthlyIncome: $('#stdFamilyMonthlyIncome  ').val(),
        DateOfBirth        : $('#stdDateOfBirth          ').val(),
        HafizEQuran        : $('#stdHafizEQuran          ').val(),
        MaritalStatus      : $('#stdMaritalStatus        ').val(),
        GuardianContactNo  : $('#stdGuardianContactNo    ').val(),
        Nationality        : $('#stdNationality          ').val(),
        DomicileDistrict   : $('#stdDomicileDistrict     ').val(),
        CreateDate         : $('#stdCreateDate           ').val(),
        UpdateDate         : $('#stdUpdateDate           ').val(),
    };
    $.ajax({
        url: "/Student/Update",
        data: JSON.stringify(studentobject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal   ').modal('hide');
            $('#stdID                 ').val("");
            $('#stdLastName           ').val("");
            $('#stdFirstMidName       ').val("");
            $('#stdEnrollmentDate     ').val("");
            $('#stdCNICBform          ').val("");
            $('#stdFatherName         ').val("");
            $('#stdFatherOccupation   ').val("");
            $('#stdGender             ').val("");
            $('#stdIslam              ').val("");
            $('#stdBloodGroup         ').val("");
            $('#stdMobileNo           ').val("");
            $('#stdEmailAddress       ').val("");
            $('#stdProvice            ').val("");
            $('#stdPermanentAddress   ').val("");
            $('#stdPostalAddress      ').val("");
            $('#stdPhoto              ').val("");
            $('#stdFatherCNIC         ').val("");
            $('#stdFamilyMonthlyIncome').val("");
            $('#stdDateOfBirth        ').val("");
            $('#stdHafizEQuran        ').val("");
            $('#stdMaritalStatus      ').val("");
            $('#stdGuardianContactNo  ').val("");
            $('#stdNationality        ').val("");
            $('#stdDomicileDistrict   ').val("");
            $('#stdCreateDate         ').val("");
            $('#stdUpdateDate         ').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Delete/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#stdID                 ').val("");
    $('#stdLastName           ').val("");
    $('#stdFirstMidName       ').val("");
    $('#stdEnrollmentDate     ').val("");
    $('#stdCNICBform          ').val("");
    $('#stdFatherName         ').val("");
    $('#stdFatherOccupation   ').val("");
    $('#stdGender             ').val("");
    $('#stdIslam              ').val("");
    $('#stdBloodGroup         ').val("");
    $('#stdMobileNo           ').val("");
    $('#stdEmailAddress       ').val("");
    $('#stdProvice            ').val("");
    $('#stdPermanentAddress   ').val("");
    $('#stdPostalAddress      ').val("");
    $('#stdPhoto              ').val("");
    $('#stdFatherCNIC         ').val("");
    $('#stdFamilyMonthlyIncome').val("");
    $('#stdDateOfBirth        ').val("");
    $('#stdHafizEQuran        ').val("");
    $('#stdMaritalStatus      ').val("");
    $('#stdGuardianContactNo  ').val("");
    $('#stdNationality        ').val("");
    $('#stdDomicileDistrict   ').val("");
    $('#stdCreateDate         ').val("");
    $('#stdUpdateDate         ').val("");


    $('#btnUpdate ').hide();
    $('#btnAdd    ').show();
    $('#stdLastName           ').css('border-color', 'lightgrey');
    $('#stdFirstMidName       ').css('border-color', 'lightgrey');
    $('#stdEnrollmentDate     ').css('border-color', 'lightgrey');
    $('#stdCNICBform          ').css('border-color', 'lightgrey');
    $('#stdFatherName         ').css('border-color', 'lightgrey');
    $('#stdFatherOccupation   ').css('border-color', 'lightgrey');
    $('#stdGender             ').css('border-color', 'lightgrey');
    $('#stdIslam              ').css('border-color', 'lightgrey');
    $('#stdBloodGroup         ').css('border-color', 'lightgrey');
    $('#stdMobileNo           ').css('border-color', 'lightgrey');
    $('#stdEmailAddress       ').css('border-color', 'lightgrey');
    $('#stdProvice            ').css('border-color', 'lightgrey');
    $('#stdPermanentAddress   ').css('border-color', 'lightgrey');
    $('#stdPostalAddress      ').css('border-color', 'lightgrey');
    $('#stdPhoto              ').css('border-color', 'lightgrey');
    $('#stdFatherCNIC         ').css('border-color', 'lightgrey');
    $('#stdFamilyMonthlyIncome').css('border-color', 'lightgrey');
    $('#stdDateOfBirth        ').css('border-color', 'lightgrey');
    $('#stdHafizEQuran        ').css('border-color', 'lightgrey');
    $('#stdMaritalStatus      ').css('border-color', 'lightgrey');
    $('#stdGuardianContactNo  ').css('border-color', 'lightgrey');
    $('#stdNationality        ').css('border-color', 'lightgrey');
    $('#stdDomicileDistrict   ').css('border-color', 'lightgrey');
    $('#stdCreateDate         ').css('border-color', 'lightgrey');
    $('#stdUpdateDate         ').css('border-color', 'lightgrey');

}
//Valdidation using jquery
//function validate() {
//    var isValid = true;
//    if ($('#Name').val().trim() == "") {
//        $('#Name').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#Name').css('border-color', 'lightgrey');
//    }
//    if ($('#Age').val().trim() == "") {
//        $('#Age').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#Age').css('border-color', 'lightgrey');
//    }
//    if ($('#State').val().trim() == "") {
//        $('#State').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#State').css('border-color', 'lightgrey');
//    }
//    if ($('#Country').val().trim() == "") {
//        $('#Country').css('border-color', 'Red');
//        isValid = false;
//    }
//    else {
//        $('#Country').css('border-color', 'lightgrey');
//    }
//    return isValid;
//}  