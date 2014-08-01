$(document).ready(function () {
	initSortableCards();
	initSortableLists();
	initAddItemMouseHover();
	initCardMouseHover();
});

function initSortableLists() {
	var positionUpdated = false;

	$('#board').sortable({
		connectWith: '#board',
		forcePlaceholderSize: true,
		placeholder: 'sortable-placeholder sortable-placeholder-list',
		update: function (event, ui) {
			positionUpdated = !ui.sender; //if no sender, set sortWithin flag to true
		},

		start: function (event, ui) {
			ui.item.addClass('item-dragging');
		},

		stop: function (event, ui) {
			ui.item.removeClass('item-dragging');

			if (positionUpdated) {

				//code

				var $this = $(this);

				positionUpdated = false;
			}
		},

		receive: function (event, ui) {
			// code
			var $this = $(this);
		}

	}).disableSelection();;
};

function initSortableCards() {
	var positionUpdated = false;

	$('.cards').sortable({
		connectWith: '.cards',
		forcePlaceholderSize: true,
		placeholder: 'sortable-placeholder',
		update: function (event, ui) {
			positionUpdated = !ui.sender; //if no sender, set sortWithin flag to true
		},

		start: function (event, ui) {
			ui.item.addClass('item-dragging');
		},

		stop: function (event, ui) {
			ui.item.removeClass('item-dragging');

			if (positionUpdated) {

				//code

				var $this = $(this);

				positionUpdated = false;
			}
		},

		receive: function (event, ui) {
			// code
			var $this = $(this);
		}

	}).disableSelection();;
};

function initAddItemMouseHover() {
	$('.add-item').mouseenter(function () {
		$(this).addClass('add-item-mouseenter');
	});

	$('.add-item').mouseleave(function () {
		$(this).removeClass('add-item-mouseenter');
	});
};

function initCardMouseHover() {
	$('.card').mouseenter(function () {
		$(this).addClass('card-mouseenter');
	});

	$('.card').mouseleave(function () {
		$(this).removeClass('card-mouseenter');
	});
}