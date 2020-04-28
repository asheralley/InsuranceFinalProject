// Custom JavaScript - Asher Alley

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

$('.carousel').carousel({
    interval: 5000
});