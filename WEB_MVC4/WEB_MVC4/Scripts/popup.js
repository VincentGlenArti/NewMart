$(document).ready(ClearAndHide);

var activewindow;

function ClearAndHide() {
    PopUpHideAll();
    $("#loginpopup").hide();
    $("#aboutpopup").hide();
    $("#callpopup").hide();
    $("#helppopup").hide();
    $("#menupopup").hide();
    $("#itempopup").hide();
    activewindow = null;
}

function PopUpShow_Mask(windowinfo) {
    if (activewindow != null) return;
    $("#popup_mask").show();
    $(windowinfo).show();
    activewindow = windowinfo;
}

function PopUpHide_Mask() {
    $(activewindow).hide();
    $("#popup_mask").hide();
    activewindow = null;
}

function PopUpHideAll() {
    PopUpHide_Mask();
}

function PopUpRegister() {
    PopUpHide_Mask();
    PopUpShow_Mask(registrationpopup);
}

function PopUpRecover() {
    PopUpHide_Mask();
    PopUpShow_Mask(recoverpopup);
}

function ResizePage() {
    var page = document.getElementById("page_border");
    var height = Math.max(document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight);
    page.style.minHeight = height + "px";
}