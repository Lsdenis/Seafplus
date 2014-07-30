$(document).ready(function() {
	initGoogleLogin();
});

function initGoogleLogin() {

	$('#login-with-google').click(function() {
		var link = 'http://localhost:3650' + loginWithGoogle;
		window.location.href = link;

	});

};