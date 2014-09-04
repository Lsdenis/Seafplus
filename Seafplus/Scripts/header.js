$(document).ready(function () {
	initBoardsMenu();
	initNotification();
});

function initBoardItemClick() {

	$('.board-list-item').click(function () {

		var id = $(this).data('id');
		window.location.href = site + board + '/' + id;

	});

};

function initNotification() {

	$.ajax({
		type: 'GET',
		url: $("#HomeIndexPath").val(),
		success: function (data) {
			$('#notification-popover-content').html(data);
		}
	});

	$('#notification-open').each(function () {

		$('#notification-open').popover({
			html: true,
			trigger: 'focus',
			container: 'body',
			placement: 'bottom',
			title: 'Activities',
			template: '<div class="popover popover-medium">' +
				'<div class="arrow"></div>' +
				'<div class="popover-inner">' +
				'<h3 class="popover-title text-center"></h3>' +
				'<div class="popover-content"><p></p>' +
				'</div></div></div>',
			content: function () {
				return $('#notification-popover-content').html();
			}
		});
	});
};

function initBoardsMenu() {

	$('#board-menu').click(function () {

		$.ajax({
			method: 'GET',
			url: site + boards,
			data: {},
			dataType: 'json',
			success: function (response) {
				if (response.success) {
					drawList(response.data);
				}
			},
			error: function () {
				alert('error');
			}
		}
		);

	});

}

function drawList(data) {
	var list = $('#board-list');
	list.find('li').remove();
	for (var i = 0; i < data.length; i++) {
		drawItem(data[i], list);
	}
	initBoardItemClick();
}

function drawItem(data, list) {
	var li = $('<li />'),
		a = $('<a />');

	li.append(a);
	list.append(li);
	a.append($('<div class="board-list-item" data-id=' + data.Id + '>' + '<span>' + data.Name + '</span>' + '</div>'));
}


