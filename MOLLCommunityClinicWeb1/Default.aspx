<%@ Page Title="Home"
Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="Default.aspx.cs"
Inherits="MOLLCommunityClinicWeb1._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

    <!-- HERO SECTION -->
    <div style="text-align:center; padding:30px;">

        <h1>🏥 MOLL Community Clinic</h1>

        <p style="font-size:18px; color:#555;">
            Your health, our priority. Manage appointments, medical records, and clinic services all in one place.
        </p>

    </div>

    <hr />

    <!-- FEATURES -->
    <div class="row">

        <!-- PATIENT -->
        <div class="col-md-4" style="text-align:center;">
            <h3>🧑‍⚕️ Patients</h3>
            <img src="Content/pdoctor.jpg"
                 style="width:100%; height:200px; object-fit:cover; border-radius:8px;" />

            <p>Book appointments, view medical history, and manage your profile.</p>
        </div>

        <!-- STAFF -->
        <div class="col-md-4" style="text-align:center;">
            <h3>👨‍⚕️ Medical Staff</h3>
            <img src="Content/doctor.jpg"
                 style="width:100%; height:200px; object-fit:cover; border-radius:8px;" />

            <p>Manage patients, appointments, inventory, and clinical records.</p>
        </div>

        <!-- APPOINTMENTS -->
        <div class="col-md-4" style="text-align:center;">
            <h3>📅 Appointments</h3>
            <img src="Content/calendar.jpg"
                 style="width:100%; height:200px; object-fit:cover; border-radius:8px;" />

            <p>Schedule, reschedule, and manage clinic appointments easily.</p>
        </div>

    </div>

    <hr />

    <!-- CALL TO ACTION -->
    <div style="text-align:center; padding:20px;">

        <h3>Get Started Today</h3>

        <p>Register or login to access your dashboard.</p>

        <a href="Registration.aspx" class="btn btn-primary">Register</a>
        <a href="PatientLogin.aspx" class="btn btn-primary">Patient Login</a>
        <a href="StaffLogin.aspx" class="btn btn-primary">Staff Login</a>

    </div>

</div>

</asp:Content>