<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReCaptcha.ascx.cs" Inherits="FrontEnd_Controls_Common_ReCaptcha" %>


<script src="https://www.google.com/recaptcha/api.js?hl=vi" async defer></script>
<div class="g-recaptcha" data-sitekey="6LcMFCMTAAAAAOWZh4e-2M270QkyDYCQ2gAfV-ac" data-callback="correctCaptcha"></div>
<script type="text/javascript">
    function validateReCaptcha() {
        var response = grecaptcha.getResponse();
        if (response.length == 0) return false;
        
        //https://www.google.com/recaptcha/api/siteverify?secret=your_secret&response=response_string
        return true;
    }
    function correctCaptcha(response) {
        console.log(response);
    }
</script>