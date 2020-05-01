// Custom JavaScript - Asher Alley

// Sticky nav activation on windo scroll
// wrapped in jquery function to protect global scope
$(function () {
    window.onscroll = function () {
        var stickyNav = document.getElementById('stickyNav');
        var currentScrollPos = window.pageYOffset;
        //console.log(currentScrollPos);
        if (currentScrollPos >= 90) {
            stickyNav.classList.remove('nav-hide');
        }
        else {
            stickyNav.classList.add('nav-hide');
        }
    }
});


// carousel init
$('.carousel').carousel({
    interval: 5000
});

// Datepicker init
$(function () {
    $('#datePicker').datepicker({
        format: 'yyyy/mm/dd',
        orientation: "bottom auto"
    });
});


// Accordian arrow rotation on collapse
// wrapped in jquery function to protect global scope
$(function () {
    var accordianEx = document.getElementById('accordionExample');

    accordianEx.addEventListener('click', rotateArrowIcon);

    function rotateArrowIcon() {
        var accordianButtons = document.body.querySelectorAll('.btn-link');

        setTimeout(function () {
            accordianButtons.forEach(function (btn) {
                //console.log(btn);
                var arrow = btn.querySelector('i');
                if (btn.classList.contains('collapsed')) {


                    arrow.classList.remove('rotate-icon');
                }
                else {
                    arrow.classList.add('rotate-icon');
                }
            });
        }, 10);

    };
})


