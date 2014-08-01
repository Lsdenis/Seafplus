$(document).ready(function() {
	initGoogleLogin();
	initSignUp();
});

function initGoogleLogin() {

	$('#login-with-google').click(function() {
		var link = 'http://localhost:3650' + loginWithGoogle;
		window.location.href = link;

	});

};

function initSignUp() {

	$('#sign-up').click(function() {
		var link = site + signUp;
		window.location.href = link;
	});

};
