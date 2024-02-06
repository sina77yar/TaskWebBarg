/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
var __webpack_exports__ = {};

    /*!****************************************************************!*\
  !*** /adminAreaAssets/js/custom/authentication/sign-in/general.js ***!
  \**********************************************************************/


// Class definition
var KTSigninGeneral = function() {
    // Elements
    var form;
    var submitButton;
    var validator;

    // Handle form
    var handleForm = function(e) {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validator = FormValidation.formValidation(
			form,
			{
				fields: {					
					'UserName': {
                        validators: {
							notEmpty: {
								message: 'شناسه کاربری اجباریه'
							},
                            stringLength: {
                                min: 4,
                                message: "از نظر من ساختار شناسه کاربریت درست نیست",
                            },
						}
					},
                    'Password': {
                        validators: {
                            notEmpty: {
                                message: 'رمـز عبور اجباریه'
                            },
                             stringLength: {
                                min: 8,
                                message: "از نظر من ساختار رمزعبورت درست نیست",
                            },
                        }
                    } 
				},
				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row'
                    })
				}
            }
        );

        // Handle form submit
        submitButton.addEventListener('click', function (e) {
            // Prevent button default action
            e.preventDefault();

            // Validate form
            validator.validate().then(function (status) {
                if (status == 'Valid') {
                    // Show loading indication
                    submitButton.setAttribute('data-kt-indicator', 'on');
                    debugger;
                    // Disable button to avoid multiple click 
                    submitButton.disabled = true;
                    var clearPassword = $('#Password').val();
                    var encriptPassword = btoa(clearPassword);
                    $('#EncriptPassword ').val(encriptPassword);

                    form.submit(); 						
                } else {
                    Swal.fire({
                        text: "متاسـفم ، یه مشکلی برای ورود شما وجود داره",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "حلـه ، فهمیـدم",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    });
                }
            });
		});
    }

    // Public functions
    return {
        // Initialization
        init: function() {
            form = document.querySelector('#kt_sign_in_form');
            submitButton = document.querySelector('#kt_sign_in_submit');
            
            handleForm();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTSigninGeneral.init();
});

/******/ })()
;