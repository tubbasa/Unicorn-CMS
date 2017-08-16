/*-----------------------------------------------------------------------------------
    Custom JS - All front-end jQuery
-----------------------------------------------------------------------------------*/

jQuery(document).ready(function($) {
    "use strict";

    /* ------------------------------------- */
    /* Search Bar
    /* ------------------------------------- */

        $('a#gp-theprint-search-trigger').click(function(e) {
            $('.gp-theprint-search-bar').toggle(10);
            e.stopPropagation();
            e.preventDefault();
        });

        $('.gp-theprint-search-bar').click(function(e) {
            e.stopPropagation();
        });

        $('.gp-theprint-container').click(function(e) {
            $('.gp-theprint-search-bar').fadeOut(10);
        });

    /* --------------------------------------- */
    /* Responsive Videos
    /* --------------------------------------- */

        $('body').fitVids();

    /* --------------------------------------- */
    /* Entry Share Bar
    /* --------------------------------------- */

        $('.single-entry-share.sticky-share').hcSticky({
            // Settings
            top: 60,
            bottomEnd: 30,
            wrapperClassName: 'single-entry-share-container'
        });

    /* --------------------------------------- */
    /* Single parallax.
    /* --------------------------------------- */

        $('a#parallax-trigger').click(function() {
            event.preventDefault();
            $('html, body').animate({
                scrollTop: $('.gp-theprint-site-main').offset().top
            }, 800);
        });

    /* --------------------------------------- */
    /* Sticky Header
    /* --------------------------------------- */

        $('.gp-theprint-site-header.sticky-header').sticky({topSpacing:0});

    /* --------------------------------------- */
    /* Sticky Secondary Navigation
    /* --------------------------------------- */

        $('.sticky-secondary-navigation').sticky({topSpacing:0});

    /* --------------------------------------- */
    /* Sticky Sidebar
    /* --------------------------------------- */

        $('.gp-theprint-sidebar.sticky-sidebar').theiaStickySidebar({
            // Settings
            additionalMarginTop: 60,
            additionalMarginBottom: 30,
            containerSelector: 'sticky-sidebar-container'
        });
        
    /* --------------------------------------- */
    /* Ending
    /* --------------------------------------- */

});// - Document ready.