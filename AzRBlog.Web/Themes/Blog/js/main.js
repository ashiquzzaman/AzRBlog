$(document).ready(function() {
	'use strict';

	$('.toggle_icon').on('click', function() {
		$('body').toggleClass('open');
	});

	// $('.side_menu .list.menu_right').mCustomScrollbar({
	// 	theme:"dark",
	// });

	// Search Toggle
	$('#search_input_box').hide();
	$('#search').on('click', function() {
		$('#search_input_box').slideToggle('slow');
		$('#search_input').focus();
	});
	$('#close_search').on('click', function() {
		$('#search_input_box').slideUp('slow');
	});

	$('#horizontalTab').jqTabs({
		direction: 'horizontal',
		duration: 200
	});

	if (document.getElementById('default-select')) {
		$('select').niceSelect();
	}

	// Initiate superfish on nav menu
	$('.nav-menu').superfish({
		animation: {
			opacity: 'show'
		},
		speed: 400
	});

	// Mobile Navigation
	if ($('#nav-menu-container').length) {
		var $mobile_nav = $('#nav-menu-container').clone().prop({
			id: 'mobile-nav'
		});
		$mobile_nav.find('> ul').attr({
			class: '',
			id: ''
		});
		$('body').append($mobile_nav);
		$('body').prepend('<button type="button" id="mobile-nav-toggle"><i class="lnr lnr-menu"></i></button>');
		$('body').append('<div id="mobile-body-overly"></div>');
		$('#mobile-nav').find('.menu-has-children').prepend('<i class="lnr lnr-chevron-down"></i>');

		$(document).on('click', '.menu-has-children i', function(e) {
			$(this).next().toggleClass('menu-item-active');
			$(this).nextAll('ul').eq(0).slideToggle();
			$(this).toggleClass('lnr-chevron-up lnr-chevron-down');
		});

		$(document).on('click', '#mobile-nav-toggle', function(e) {
			$('body').toggleClass('mobile-nav-active');
			$('#mobile-nav-toggle i').toggleClass('lnr-cross lnr-menu');
			$('#mobile-body-overly').toggle();
		});

		$(document).click(function(e) {
			var container = $('#mobile-nav, #mobile-nav-toggle');
			if (!container.is(e.target) && container.has(e.target).length === 0) {
				if ($('body').hasClass('mobile-nav-active')) {
					$('body').removeClass('mobile-nav-active');
					$('#mobile-nav-toggle i').toggleClass('lnr-cross lnr-menu');
					$('#mobile-body-overly').fadeOut();
				}
			}
		});
	} else if ($('#mobile-nav, #mobile-nav-toggle').length) {
		$('#mobile-nav, #mobile-nav-toggle').hide();
	}

	// Smooth scroll for the menu and links with .scrollto classes
	$('.nav-menu a, #mobile-nav a, .scrollto').on('click', function() {
		if (
			location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') &&
			location.hostname == this.hostname
		) {
			var target = $(this.hash);
			if (target.length) {
				var top_space = 0;

				if ($('#header').length) {
					top_space = $('#header').outerHeight();

					if (!$('#header').hasClass('header-fixed')) {
						top_space = top_space;
					}
				}

				$('html, body').animate(
					{
						scrollTop: target.offset().top - top_space
					},
					1500,
					'easeInOutExpo'
				);

				if ($(this).parents('.nav-menu').length) {
					$('.nav-menu .menu-active').removeClass('menu-active');
					$(this).closest('li').addClass('menu-active');
				}

				if ($('body').hasClass('mobile-nav-active')) {
					$('body').removeClass('mobile-nav-active');
					$('#mobile-nav-toggle i').toggleClass('lnr-times lnr-bars');
					$('#mobile-body-overly').fadeOut();
				}
				return false;
			}
		}
	});

	$(document).ready(function() {
		$('html, body').hide();
		if (window.location.hash) {
			setTimeout(function() {
				$('html, body').scrollTop(0).show();
				$('html, body').animate(
					{
						scrollTop: $(window.location.hash).offset().top - 108
					},
					1000
				);
			}, 0);
		} else {
			$('html, body').show();
		}
	});

	// Header scroll class
	$(window).scroll(function() {
		if ($(this).scrollTop() > 100) {
			$('#header').addClass('header-scrolled');
		} else {
			$('#header').removeClass('header-scrolled');
		}
	});

	// top stories carousel js //
	$('.active-stories-carousel').owlCarousel({
		items: 6,
		loop: true,
		margin: 0,
		dots: false,
		nav: false,
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 1
			},
			650: {
				items: 2
			},
			768: {
				items: 2
			},
			992: {
				items: 3
			},
			1200: {
				items: 4
			},
			1681: {
				items: 6
			}
		}
	});

	// post carousel js //
	$('.active-post-carusel').owlCarousel({
		items: 3,
		loop: true,
		margin: 0,
		dots: false,
		nav: false,
		responsive: {
			0: {
				items: 1
			},
			480: {
				items: 1
			},
			768: {
				items: 1
			},
			800: {
				items: 2
			},
			1200: {
				items: 2
			},
			1380: {
				items: 3
			}
		}
	});

	//  Start Google map

	// When the window has finished loading create our google map below

	if (document.getElementById('map')) {
		google.maps.event.addDomListener(window, 'load', init);
		function init() {
			// Basic options for a simple Google Map
			// For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
			var mapOptions = {
				// How zoomed in you want the map to start at (always required)
				zoom: 11,
				// The latitude and longitude to center the map (always required)
				center: new google.maps.LatLng(40.67, -73.94), // New York
				// How you would like to style the map.
				// This is where you would paste any style found on Snazzy Maps.
				styles: [
					{
						featureType: 'water',
						elementType: 'geometry',
						stylers: [ { color: '#e9e9e9' }, { lightness: 17 } ]
					},
					{
						featureType: 'landscape',
						elementType: 'geometry',
						stylers: [ { color: '#f5f5f5' }, { lightness: 20 } ]
					},
					{
						featureType: 'road.highway',
						elementType: 'geometry.fill',
						stylers: [ { color: '#ffffff' }, { lightness: 17 } ]
					},
					{
						featureType: 'road.highway',
						elementType: 'geometry.stroke',
						stylers: [ { color: '#ffffff' }, { lightness: 29 }, { weight: 0.2 } ]
					},
					{
						featureType: 'road.arterial',
						elementType: 'geometry',
						stylers: [ { color: '#ffffff' }, { lightness: 18 } ]
					},
					{
						featureType: 'road.local',
						elementType: 'geometry',
						stylers: [ { color: '#ffffff' }, { lightness: 16 } ]
					},
					{
						featureType: 'poi',
						elementType: 'geometry',
						stylers: [ { color: '#f5f5f5' }, { lightness: 21 } ]
					},
					{
						featureType: 'poi.park',
						elementType: 'geometry',
						stylers: [ { color: '#dedede' }, { lightness: 21 } ]
					},
					{
						elementType: 'labels.text.stroke',
						stylers: [ { visibility: 'on' }, { color: '#ffffff' }, { lightness: 16 } ]
					},
					{
						elementType: 'labels.text.fill',
						stylers: [ { saturation: 36 }, { color: '#333333' }, { lightness: 40 } ]
					},
					{ elementType: 'labels.icon', stylers: [ { visibility: 'off' } ] },
					{
						featureType: 'transit',
						elementType: 'geometry',
						stylers: [ { color: '#f2f2f2' }, { lightness: 19 } ]
					},
					{
						featureType: 'administrative',
						elementType: 'geometry.fill',
						stylers: [ { color: '#fefefe' }, { lightness: 20 } ]
					},
					{
						featureType: 'administrative',
						elementType: 'geometry.stroke',
						stylers: [ { color: '#fefefe' }, { lightness: 17 }, { weight: 1.2 } ]
					}
				]
			};

			// Get the HTML DOM element that will contain your map
			// We are using a div with id="map" seen below in the <body>
			var mapElement = document.getElementById('map');

			// Create the Google Map using our element and options defined above
			var map = new google.maps.Map(mapElement, mapOptions);

			// Let's also add a marker while we're at it
			var marker = new google.maps.Marker({
				position: new google.maps.LatLng(40.67, -73.94),
				map: map,
				title: 'Snazzy!'
			});
		}
	}

	$(document).ready(function() {
		$('#mc_embed_signup').find('form').ajaxChimp();
	});
});
