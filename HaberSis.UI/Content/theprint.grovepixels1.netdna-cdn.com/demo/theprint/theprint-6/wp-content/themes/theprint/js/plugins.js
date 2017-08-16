/*!
* FitVids 1.1
*
* Copyright 2013, Chris Coyier - http://css-tricks.com + Dave Rupert - http://daverupert.com
* Credit to Thierry Koblentz - http://www.alistapart.com/articles/creating-intrinsic-ratios-for-video/
* Released under the WTFPL license - http://sam.zoy.org/wtfpl/
*
*/
;(function(a){a.fn.fitVids=function(b){var e={customSelector:null,ignore:null};if(!document.getElementById("fit-vids-style")){var d=document.head||document.getElementsByTagName("head")[0];var c=".fluid-width-video-wrapper{width:100%;position:relative;padding:0;}.fluid-width-video-wrapper iframe,.fluid-width-video-wrapper object,.fluid-width-video-wrapper embed {position:absolute;top:0;left:0;width:100%;height:100%;}";var f=document.createElement("div");f.innerHTML='<p>x</p><style id="fit-vids-style">'+c+"</style>";d.appendChild(f.childNodes[1])}if(b){a.extend(e,b)}return this.each(function(){var g=['iframe[src*="dailymotion.com"]','iframe[src*="player.vimeo.com"]','iframe[src*="youtube.com"]','iframe[src*="youtube-nocookie.com"]','iframe[src*="kickstarter.com"][src*="video.html"]',"object","embed"];if(e.customSelector){g.push(e.customSelector)}var h=".fitvidsignore";if(e.ignore){h=h+", "+e.ignore}var i=a(this).find(g.join(","));i=i.not("object object");i=i.not(h);i.each(function(){var n=a(this);if(n.parents(h).length>0){return}if(this.tagName.toLowerCase()==="embed"&&n.parent("object").length||n.parent(".fluid-width-video-wrapper").length){return}if((!n.css("height")&&!n.css("width"))&&(isNaN(n.attr("height"))||isNaN(n.attr("width")))){n.attr("height",9);n.attr("width",16)}var j=(this.tagName.toLowerCase()==="object"||(n.attr("height")&&!isNaN(parseInt(n.attr("height"),10))))?parseInt(n.attr("height"),10):n.height(),k=!isNaN(parseInt(n.attr("width"),10))?parseInt(n.attr("width"),10):n.width(),l=j/k;if(!n.attr("id")){var m="fitvid"+Math.floor(Math.random()*999999);n.attr("id",m)}n.wrap('<div class="fluid-width-video-wrapper"></div>').parent(".fluid-width-video-wrapper").css("padding-top",(l*100)+"%");n.removeAttr("height").removeAttr("width")})})}})(window.jQuery||window.Zepto);(function(f){var e={topSpacing:0,bottomSpacing:0,className:"is-sticky",wrapperClassName:"sticky-wrapper",center:false,getWidthFrom:"",responsiveWidth:false},b=f(window),d=f(document),i=[],a=b.height(),g=function(){var j=b.scrollTop(),q=d.height(),p=q-a,l=(j>p)?p-j:0;for(var m=0;m<i.length;m++){var r=i[m],k=r.stickyWrapper.offset().top,n=k-r.topSpacing-l;if(j<=n){if(r.currentTop!==null){r.stickyElement.css("position","").css("top","");r.stickyElement.trigger("sticky-end",[r]).parent().removeClass(r.className);r.currentTop=null}}else{var o=q-r.stickyElement.outerHeight()-r.topSpacing-r.bottomSpacing-j-l;if(o<0){o=o+r.topSpacing}else{o=r.topSpacing}if(r.currentTop!=o){r.stickyElement.css("position","fixed").css("top",o);if(typeof r.getWidthFrom!=="undefined"){r.stickyElement.css("width",f(r.getWidthFrom).width())}r.stickyElement.trigger("sticky-start",[r]).parent().addClass(r.className);r.currentTop=o}}}},h=function(){a=b.height();for(var j=0;j<i.length;j++){var k=i[j];if(typeof k.getWidthFrom!=="undefined"&&k.responsiveWidth===true){k.stickyElement.css("width",f(k.getWidthFrom).width())}}},c={init:function(j){var k=f.extend({},e,j);return this.each(function(){var l=f(this);var m=l.attr("id");var o=m?m+"-"+e.wrapperClassName:e.wrapperClassName;var p=f("<div></div>").attr("id",m+"-sticky-wrapper").addClass(k.wrapperClassName);l.wrapAll(p);if(k.center){l.parent().css({width:l.outerWidth(),marginLeft:"auto",marginRight:"auto"})}if(l.css("float")=="right"){l.css({"float":"none"}).parent().css({"float":"right"})}var n=l.parent();n.css("height",l.outerHeight());i.push({topSpacing:k.topSpacing,bottomSpacing:k.bottomSpacing,stickyElement:l,currentTop:null,stickyWrapper:n,className:k.className,getWidthFrom:k.getWidthFrom,responsiveWidth:k.responsiveWidth})})},update:g,unstick:function(j){return this.each(function(){var l=f(this);var k=-1;for(var m=0;m<i.length;m++){if(i[m].stickyElement.get(0)==l.get(0)){k=m}}if(k!=-1){i.splice(k,1);l.unwrap();l.removeAttr("style")}})}};if(window.addEventListener){window.addEventListener("scroll",g,false);window.addEventListener("resize",h,false)}else{if(window.attachEvent){window.attachEvent("onscroll",g);window.attachEvent("onresize",h)}}f.fn.sticky=function(j){if(c[j]){return c[j].apply(this,Array.prototype.slice.call(arguments,1))}else{if(typeof j==="object"||!j){return c.init.apply(this,arguments)}else{f.error("Method "+j+" does not exist on jQuery.sticky")}}};f.fn.unstick=function(j){if(c[j]){return c[j].apply(this,Array.prototype.slice.call(arguments,1))}else{if(typeof j==="object"||!j){return c.unstick.apply(this,arguments)}else{f.error("Method "+j+" does not exist on jQuery.sticky")}}};f(function(){setTimeout(g,0)})})(jQuery);
/*!
 * Retina.js v1.3.0
 *
 * Copyright 2014 Imulus, LLC
 * Released under the MIT license
 *
 * Retina.js is an open source script that makes it easy to serve
 * high-resolution images to devices with retina displays.
 */
!function(){function a(){}function b(a){return f.retinaImageSuffix+a}function c(a,c){if(this.path=a||"","undefined"!=typeof c&&null!==c)this.at_2x_path=c,this.perform_check=!1;else{if(void 0!==document.createElement){var d=document.createElement("a");d.href=this.path,d.pathname=d.pathname.replace(g,b),this.at_2x_path=d.href}else{var e=this.path.split("?");e[0]=e[0].replace(g,b),this.at_2x_path=e.join("?")}this.perform_check=!0}}function d(a){this.el=a,this.path=new c(this.el.getAttribute("src"),this.el.getAttribute("data-at2x"));var b=this;this.path.check_2x_variant(function(a){a&&b.swap()})}var e="undefined"==typeof exports?window:exports,f={retinaImageSuffix:"@2x",check_mime_type:!0,force_original_dimensions:!0};e.Retina=a,a.configure=function(a){null===a&&(a={});for(var b in a)a.hasOwnProperty(b)&&(f[b]=a[b])},a.init=function(a){null===a&&(a=e);var b=a.onload||function(){};a.onload=function(){var a,c,e=document.getElementsByTagName("img"),f=[];for(a=0;a<e.length;a+=1)c=e[a],c.getAttributeNode("data-no-retina")||f.push(new d(c));b()}},a.isRetina=function(){var a="(-webkit-min-device-pixel-ratio: 1.5), (min--moz-device-pixel-ratio: 1.5), (-o-min-device-pixel-ratio: 3/2), (min-resolution: 1.5dppx)";return e.devicePixelRatio>1?!0:e.matchMedia&&e.matchMedia(a).matches?!0:!1};var g=/\.\w+$/;e.RetinaImagePath=c,c.confirmed_paths=[],c.prototype.is_external=function(){return!(!this.path.match(/^https?\:/i)||this.path.match("//"+document.domain))},c.prototype.check_2x_variant=function(a){var b,d=this;return this.is_external()?a(!1):this.perform_check||"undefined"==typeof this.at_2x_path||null===this.at_2x_path?this.at_2x_path in c.confirmed_paths?a(!0):(b=new XMLHttpRequest,b.open("HEAD",this.at_2x_path),b.onreadystatechange=function(){if(4!==b.readyState)return a(!1);if(b.status>=200&&b.status<=399){if(f.check_mime_type){var e=b.getResponseHeader("Content-Type");if(null===e||!e.match(/^image/i))return a(!1)}return c.confirmed_paths.push(d.at_2x_path),a(!0)}return a(!1)},b.send(),void 0):a(!0)},e.RetinaImage=d,d.prototype.swap=function(a){function b(){c.el.complete?(f.force_original_dimensions&&(c.el.setAttribute("width",c.el.offsetWidth),c.el.setAttribute("height",c.el.offsetHeight)),c.el.setAttribute("src",a)):setTimeout(b,5)}"undefined"==typeof a&&(a=this.path.at_2x_path);var c=this;b()},a.isRetina()&&a.init(e)}();
// Sticky Plugin v1.0.3 for jQuery
// =============
// Author: Anthony Garand
// Improvements by German M. Bravo (Kronuz) and Ruud Kamphuis (ruudk)
// Improvements by Leonardo C. Daronco (daronco)
// Created: 02/14/2011
// Date: 07/20/2015
// Website: http://stickyjs.com/
// Description: Makes an element on the page stick on the screen as you scroll
//              It will only set the 'top' and 'position' of your element, you
//              might need to adjust the width in some cases.
!function(t){"function"==typeof define&&define.amd?define(["jquery"],t):"object"==typeof module&&module.exports?module.exports=t(require("jquery")):t(jQuery)}(function(t){var e=Array.prototype.slice,i=Array.prototype.splice,r={topSpacing:0,bottomSpacing:0,className:"is-sticky",wrapperClassName:"sticky-wrapper",center:!1,getWidthFrom:"",widthFromWrapper:!0,responsiveWidth:!1},n=t(window),o=t(document),s=[],c=n.height(),a=function(){for(var e=n.scrollTop(),i=o.height(),r=i-c,a=e>r?r-e:0,p=0,l=s.length;l>p;p++){var u=s[p],d=u.stickyWrapper.offset().top,h=d-u.topSpacing-a;if(u.stickyWrapper.css("height",u.stickyElement.outerHeight()),h>=e)null!==u.currentTop&&(u.stickyElement.css({width:"",position:"",top:""}),u.stickyElement.parent().removeClass(u.className),u.stickyElement.trigger("sticky-end",[u]),u.currentTop=null);else{var m=i-u.stickyElement.outerHeight()-u.topSpacing-u.bottomSpacing-e-a;if(0>m?m+=u.topSpacing:m=u.topSpacing,u.currentTop!==m){var y;u.getWidthFrom?y=t(u.getWidthFrom).width()||null:u.widthFromWrapper&&(y=u.stickyWrapper.width()),null==y&&(y=u.stickyElement.width()),u.stickyElement.css("width",y).css("position","fixed").css("top",m),u.stickyElement.parent().addClass(u.className),null===u.currentTop?u.stickyElement.trigger("sticky-start",[u]):u.stickyElement.trigger("sticky-update",[u]),u.currentTop===u.topSpacing&&u.currentTop>m||null===u.currentTop&&m<u.topSpacing?u.stickyElement.trigger("sticky-bottom-reached",[u]):null!==u.currentTop&&m===u.topSpacing&&u.currentTop<m&&u.stickyElement.trigger("sticky-bottom-unreached",[u]),u.currentTop=m}}}},p=function(){c=n.height();for(var e=0,i=s.length;i>e;e++){var r=s[e],o=null;r.getWidthFrom?r.responsiveWidth&&(o=t(r.getWidthFrom).width()):r.widthFromWrapper&&(o=r.stickyWrapper.width()),null!=o&&r.stickyElement.css("width",o)}},l={init:function(e){var i=t.extend({},r,e);return this.each(function(){var e=t(this),n=e.attr("id"),o=e.outerHeight(),c=n?n+"-"+r.wrapperClassName:r.wrapperClassName,a=t("<div></div>").attr("id",c).addClass(i.wrapperClassName);e.wrapAll(a);var p=e.parent();i.center&&p.css({width:e.outerWidth(),marginLeft:"auto",marginRight:"auto"}),"right"===e.css("float")&&e.css({"float":"none"}).parent().css({"float":"right"}),p.css("height",o),i.stickyElement=e,i.stickyWrapper=p,i.currentTop=null,s.push(i)})},update:a,unstick:function(){return this.each(function(){for(var e=this,r=t(e),n=-1,o=s.length;o-->0;)s[o].stickyElement.get(0)===e&&(i.call(s,o,1),n=o);-1!==n&&(r.unwrap(),r.css({width:"",position:"",top:"","float":""}))})}};window.addEventListener?(window.addEventListener("scroll",a,!1),window.addEventListener("resize",p,!1)):window.attachEvent&&(window.attachEvent("onscroll",a),window.attachEvent("onresize",p)),t.fn.sticky=function(i){return l[i]?l[i].apply(this,e.call(arguments,1)):"object"!=typeof i&&i?void t.error("Method "+i+" does not exist on jQuery.sticky"):l.init.apply(this,arguments)},t.fn.unstick=function(i){return l[i]?l[i].apply(this,e.call(arguments,1)):"object"!=typeof i&&i?void t.error("Method "+i+" does not exist on jQuery.sticky"):l.unstick.apply(this,arguments)},t(function(){setTimeout(a,0)})});
// jQuery HC-Sticky
// =============
// Version: 1.2.43
// Copyright: Some Web Media
// Author: Some Web Guy
// Author URL: http://twitter.com/some_web_guy
// Website: http://someweblog.com/
// Plugin URL: https://github.com/somewebmedia/hc-sticky
// License: Released under the MIT License www.opensource.org/licenses/mit-license.php
// Description: Cross-browser jQuery plugin that makes any element attached to the page and always visible while you scroll.
(function(e,t,n){"use strict";var r=function(e){console.log(e)};var i=e(t),s=t.document,o=e(s);var u=function(){var e,t=3,n=s.createElement("div"),r=n.getElementsByTagName("i");while(n.innerHTML="<!--[if gt IE "+ ++t+"]><i></i><![endif]-->",r[0]){}return t>4?t:e}();var a=function(){var e=t.pageXOffset!==n?t.pageXOffset:s.compatMode=="CSS1Compat"?t.document.documentElement.scrollLeft:t.document.body.scrollLeft,r=t.pageYOffset!==n?t.pageYOffset:s.compatMode=="CSS1Compat"?t.document.documentElement.scrollTop:t.document.body.scrollTop;if(typeof a.x=="undefined"){a.x=e;a.y=r}if(typeof a.distanceX=="undefined"){a.distanceX=e;a.distanceY=r}else{a.distanceX=e-a.x;a.distanceY=r-a.y}var i=a.x-e,o=a.y-r;a.direction=i<0?"right":i>0?"left":o<=0?"down":o>0?"up":"first";a.x=e;a.y=r};i.on("scroll",a);e.fn.style=function(n){if(!n)return null;var r=e(this),i;var o=r.clone().css("display","none");o.find("input:radio").attr("name","copy-"+Math.floor(Math.random()*100+1));r.after(o);var u=function(e,n){var i;if(e.currentStyle){i=e.currentStyle[n.replace(/-\w/g,function(e){return e.toUpperCase().replace("-","")})]}else if(t.getComputedStyle){i=s.defaultView.getComputedStyle(e,null).getPropertyValue(n)}i=/margin/g.test(n)?parseInt(i)===r[0].offsetLeft?i:"auto":i;return i};if(typeof n=="string"){i=u(o[0],n)}else{i={};e.each(n,function(e,t){i[t]=u(o[0],t)})}o.remove();return i||null};e.fn.extend({hcSticky:function(r){if(this.length==0)return this;this.pluginOptions("hcSticky",{top:0,bottom:0,bottomEnd:0,innerTop:0,innerSticker:null,className:"sticky",wrapperClassName:"wrapper-sticky",stickTo:null,responsive:true,followScroll:true,offResolutions:null,onStart:e.noop,onStop:e.noop,on:true,fn:null},r||{},{reinit:function(){e(this).hcSticky()},stop:function(){e(this).pluginOptions("hcSticky",{on:false}).each(function(){var t=e(this),n=t.pluginOptions("hcSticky"),r=t.parent("."+n.wrapperClassName);var i=t.offset().top-r.offset().top;t.css({position:"absolute",top:i,bottom:"auto",left:"auto",right:"auto"}).removeClass(n.className)})},off:function(){e(this).pluginOptions("hcSticky",{on:false}).each(function(){var t=e(this),n=t.pluginOptions("hcSticky"),r=t.parent("."+n.wrapperClassName);t.css({position:"relative",top:"auto",bottom:"auto",left:"auto",right:"auto"}).removeClass(n.className);r.css("height","auto")})},on:function(){e(this).each(function(){e(this).pluginOptions("hcSticky",{on:true,remember:{offsetTop:i.scrollTop()}}).hcSticky()})},destroy:function(){var t=e(this),n=t.pluginOptions("hcSticky"),r=t.parent("."+n.wrapperClassName);t.removeData("hcStickyInit").css({position:r.css("position"),top:r.css("top"),bottom:r.css("bottom"),left:r.css("left"),right:r.css("right")}).removeClass(n.className);i.off("resize",n.fn.resize).off("scroll",n.fn.scroll);t.unwrap()}});if(r&&typeof r.on!="undefined"){if(r.on){this.hcSticky("on")}else{this.hcSticky("off")}}if(typeof r=="string")return this;return this.each(function(){var r=e(this),s=r.pluginOptions("hcSticky");var f=function(){var e=r.parent("."+s.wrapperClassName);if(e.length>0){e.css({height:r.outerHeight(true),width:function(){var t=e.style("width");if(t.indexOf("%")>=0||t=="auto"){if(r.css("box-sizing")=="border-box"||r.css("-moz-box-sizing")=="border-box"){r.css("width",e.width())}else{r.css("width",e.width()-parseInt(r.css("padding-left")-parseInt(r.css("padding-right"))))}return t}else{return r.outerWidth(true)}}()});return e}else{return false}}()||function(){var t=r.style(["width","margin-left","left","right","top","bottom","float","display"]);var n=r.css("display");var i=e("<div>",{"class":s.wrapperClassName}).css({display:n,height:r.outerHeight(true),width:function(){if(t["width"].indexOf("%")>=0||t["width"]=="auto"&&n!="inline-block"&&n!="inline"){r.css("width",parseFloat(r.css("width")));return t["width"]}else if(t["width"]=="auto"&&(n=="inline-block"||n=="inline")){return r.width()}else{return t["margin-left"]=="auto"?r.outerWidth():r.outerWidth(true)}}(),margin:t["margin-left"]?"auto":null,position:function(){var e=r.css("position");return e=="static"?"relative":e}(),"float":t["float"]||null,left:t["left"],right:t["right"],top:t["top"],bottom:t["bottom"],"vertical-align":"top"});r.wrap(i);if(u===7){if(e("head").find("style#hcsticky-iefix").length===0){e('<style id="hcsticky-iefix">.'+s.wrapperClassName+" {zoom: 1;}</style>").appendTo("head")}}return r.parent()}();if(r.data("hcStickyInit"))return;r.data("hcStickyInit",true);var l=s.stickTo&&(s.stickTo=="document"||s.stickTo.nodeType&&s.stickTo.nodeType==9||typeof s.stickTo=="object"&&s.stickTo instanceof(typeof HTMLDocument!="undefined"?HTMLDocument:Document))?true:false;var c=s.stickTo?l?o:typeof s.stickTo=="string"?e(s.stickTo):s.stickTo:f.parent();r.css({top:"auto",bottom:"auto",left:"auto",right:"auto"});i.load(function(){if(r.outerHeight(true)>c.height()){f.css("height",r.outerHeight(true));r.hcSticky("reinit")}});var h=function(e){if(r.hasClass(s.className))return;e=e||{};r.css({position:"fixed",top:e.top||0,left:e.left||f.offset().left}).addClass(s.className);s.onStart.apply(r[0]);f.addClass("sticky-active")},p=function(e){e=e||{};e.position=e.position||"absolute";e.top=e.top||0;e.left=e.left||0;if(r.css("position")!="fixed"&&parseInt(r.css("top"))==e.top)return;r.css({position:e.position,top:e.top,left:e.left}).removeClass(s.className);s.onStop.apply(r[0]);f.removeClass("sticky-active")};var d=function(t){if(!s.on||!r.is(":visible"))return;if(r.outerHeight(true)>=c.height()){p();return}var n=s.innerSticker?e(s.innerSticker).position().top:s.innerTop?s.innerTop:0,o=f.offset().top,u=c.height()-s.bottomEnd+(l?0:o),d=f.offset().top-s.top+n,v=r.outerHeight(true)+s.bottom,m=i.height(),g=i.scrollTop(),y=r.offset().top,b=y-g,w;if(typeof s.remember!="undefined"&&s.remember){var E=y-s.top-n;if(v-n>m&&s.followScroll){if(E<g&&g+m<=E+r.height()){s.remember=false}}else{if(s.remember.offsetTop>E){if(g<=E){h({top:s.top-n});s.remember=false}}else{if(g>=E){h({top:s.top-n});s.remember=false}}}return}if(g>d){if(u+s.bottom-(s.followScroll&&m<v?0:s.top)<=g+v-n-(v-n>m-(d-n)&&s.followScroll?(w=v-m-n)>0?w:0:0)){p({top:u-v+s.bottom-o})}else if(v-n>m&&s.followScroll){if(b+v<=m){if(a.direction=="down"){h({top:m-v})}else{if(b<0&&r.css("position")=="fixed"){p({top:y-(d+s.top-n)-a.distanceY})}}}else{if(a.direction=="up"&&y>=g+s.top-n){h({top:s.top-n})}else if(a.direction=="down"&&y+v>m&&r.css("position")=="fixed"){p({top:y-(d+s.top-n)-a.distanceY})}}}else{h({top:s.top-n})}}else{p()}};var v=false,m=false;var g=function(){b();y();if(!s.on)return;var e=function(){if(r.css("position")=="fixed"){r.css("left",f.offset().left)}else{r.css("left",0)}};if(s.responsive){if(!m){m=r.clone().attr("style","").css({visibility:"hidden",height:0,overflow:"hidden",paddingTop:0,paddingBottom:0,marginTop:0,marginBottom:0});f.after(m)}var t=f.style("width");var n=m.style("width");if(n=="auto"&&t!="auto"){n=parseInt(r.css("width"))}if(n!=t){f.width(n)}if(v){clearTimeout(v)}v=setTimeout(function(){v=false;m.remove();m=false},250)}e();if(r.outerWidth(true)!=f.width()){var i=r.css("box-sizing")=="border-box"||r.css("-moz-box-sizing")=="border-box"?f.width():f.width()-parseInt(r.css("padding-left"))-parseInt(r.css("padding-right"));i=i-parseInt(r.css("margin-left"))-parseInt(r.css("margin-right"));r.css("width",i)}};r.pluginOptions("hcSticky",{fn:{scroll:d,resize:g}});var y=function(){if(s.offResolutions){if(!e.isArray(s.offResolutions)){s.offResolutions=[s.offResolutions]}var t=true;e.each(s.offResolutions,function(e,n){if(n<0){if(i.width()<n*-1){t=false;r.hcSticky("off")}}else{if(i.width()>n){t=false;r.hcSticky("off")}}});if(t&&!s.on){r.hcSticky("on")}}};y();i.on("resize",g);var b=function(){var r=false;if(e._data(t,"events").scroll!=n){e.each(e._data(t,"events").scroll,function(e,t){if(t.handler==s.fn.scroll){r=true}})}if(!r){s.fn.scroll(true);i.on("scroll",s.fn.scroll)}};b()})}})})(jQuery,this);(function(e,t){"use strict";e.fn.extend({pluginOptions:function(n,r,i,s){if(!this.data(n))this.data(n,{});if(n&&typeof r=="undefined")return this.data(n).options;i=i||r||{};if(typeof i=="object"||i===t){return this.each(function(){var t=e(this);if(!t.data(n).options){t.data(n,{options:e.extend(r,i||{})});if(s){t.data(n).commands=s}}else{t.data(n,e.extend(t.data(n),{options:e.extend(t.data(n).options,i||{})}))}})}else if(typeof i=="string"){return this.each(function(){e(this).data(n).commands[i].call(this)})}else{return this}}})})(jQuery)
/*!
 * Theia Sticky Sidebar v1.3.0
 * https://github.com/WeCodePixels/theia-sticky-sidebar
 *
 * Glues your website's sidebars, making them permanently visible while scrolling.
 *
 * Copyright 2013-2014 WeCodePixels and other contributors
 * Released under the MIT license
 */
!function(i){i.fn.theiaStickySidebar=function(t){function o(t,o){var a=e(t,o);a||(console.log("TST: Body width smaller than options.minWidth. Init is delayed."),i(document).scroll(function(t,o){return function(a){var n=e(t,o);n&&i(this).unbind(a)}}(t,o)),i(window).resize(function(t,o){return function(a){var n=e(t,o);n&&i(this).unbind(a)}}(t,o)))}function e(t,o){return t.initialized===!0?!0:i("body").width()<t.minWidth?!1:(a(t,o),!0)}function a(t,o){t.initialized=!0,i("head").append(i('<style>.theiaStickySidebar:after {content: ""; display: table; clear: both;}</style>')),o.each(function(){function o(){a.fixedScrollTop=0,a.sidebar.css({"min-height":"1px"}),a.stickySidebar.css({position:"static",width:""})}function e(t){var o=t.height();return t.children().each(function(){o=Math.max(o,i(this).height())}),o}console.log("TST: Doing init.");var a={};a.sidebar=i(this),a.options=t||{},a.container=i(a.options.containerSelector),0==a.container.size()&&(a.container=a.sidebar.parent()),a.sidebar.parents().css("-webkit-transform","none"),a.sidebar.css({position:"relative",overflow:"visible","-webkit-box-sizing":"border-box","-moz-box-sizing":"border-box","box-sizing":"border-box"}),a.stickySidebar=a.sidebar.find(".theiaStickySidebar"),0==a.stickySidebar.length&&(a.sidebar.find("script").remove(),a.stickySidebar=i("<div>").addClass("theiaStickySidebar").append(a.sidebar.children()),a.sidebar.append(a.stickySidebar)),a.marginTop=parseInt(a.sidebar.css("margin-top")),a.marginBottom=parseInt(a.sidebar.css("margin-bottom")),a.paddingTop=parseInt(a.sidebar.css("padding-top")),a.paddingBottom=parseInt(a.sidebar.css("padding-bottom"));var n=a.stickySidebar.offset().top,d=a.stickySidebar.outerHeight();a.stickySidebar.css("padding-top",1),a.stickySidebar.css("padding-bottom",1),n-=a.stickySidebar.offset().top,d=a.stickySidebar.outerHeight()-d-n,0==n?(a.stickySidebar.css("padding-top",0),a.stickySidebarPaddingTop=0):a.stickySidebarPaddingTop=1,0==d?(a.stickySidebar.css("padding-bottom",0),a.stickySidebarPaddingBottom=0):a.stickySidebarPaddingBottom=1,a.previousScrollTop=null,a.fixedScrollTop=0,o(),a.onScroll=function(a){if(a.stickySidebar.is(":visible")){if(i("body").width()<a.options.minWidth)return void o();if(a.sidebar.outerWidth(!0)+50>a.container.width())return void o();var n=i(document).scrollTop(),d="static";if(n>=a.container.offset().top+(a.paddingTop+a.marginTop-a.options.additionalMarginTop)){var r,s=a.paddingTop+a.marginTop+t.additionalMarginTop,c=a.paddingBottom+a.marginBottom+t.additionalMarginBottom,p=a.container.offset().top,b=a.container.offset().top+e(a.container),g=0+t.additionalMarginTop,l=a.stickySidebar.outerHeight()+s+c<i(window).height();r=l?g+a.stickySidebar.outerHeight():i(window).height()-a.marginBottom-a.paddingBottom-t.additionalMarginBottom;var h=p-n+a.paddingTop+a.marginTop,f=b-n-a.paddingBottom-a.marginBottom,S=a.stickySidebar.offset().top-n,u=a.previousScrollTop-n;"fixed"==a.stickySidebar.css("position")&&"modern"==a.options.sidebarBehavior&&(S+=u),"legacy"==a.options.sidebarBehavior&&(S=r-a.stickySidebar.outerHeight(),S=Math.max(S,r-a.stickySidebar.outerHeight())),S=u>0?Math.min(S,g):Math.max(S,r-a.stickySidebar.outerHeight()),S=Math.max(S,h),S=Math.min(S,f-a.stickySidebar.outerHeight());var m=a.container.height()==a.stickySidebar.outerHeight();d=(m||S!=g)&&(m||S!=r-a.stickySidebar.outerHeight())?n+S-a.sidebar.offset().top-a.paddingTop<=t.additionalMarginTop?"static":"absolute":"fixed"}if("fixed"==d)a.stickySidebar.css({position:"fixed",width:a.sidebar.width(),top:S,left:a.sidebar.offset().left+parseInt(a.sidebar.css("padding-left"))});else if("absolute"==d){var y={};"absolute"!=a.stickySidebar.css("position")&&(y.position="absolute",y.top=n+S-a.sidebar.offset().top-a.stickySidebarPaddingTop-a.stickySidebarPaddingBottom),y.width=a.sidebar.width(),y.left="",a.stickySidebar.css(y)}else"static"==d&&o();"static"!=d&&1==a.options.updateSidebarHeight&&a.sidebar.css({"min-height":a.stickySidebar.outerHeight()+a.stickySidebar.offset().top-a.sidebar.offset().top+a.paddingBottom}),a.previousScrollTop=n}},a.onScroll(a),i(document).scroll(function(i){return function(){i.onScroll(i)}}(a)),i(window).resize(function(i){return function(){i.stickySidebar.css({position:"static"}),i.onScroll(i)}}(a))})}var n={containerSelector:"",additionalMarginTop:0,additionalMarginBottom:0,updateSidebarHeight:!0,minWidth:0,sidebarBehavior:"modern"};t=i.extend(n,t),t.additionalMarginTop=parseInt(t.additionalMarginTop)||0,t.additionalMarginBottom=parseInt(t.additionalMarginBottom)||0,o(t,this)}}(jQuery);
/*!
 * parallax.js v1.3.1 (http://pixelcog.github.io/parallax.js/)
 * @copyright 2015 PixelCog, Inc.
 * @license MIT (https://github.com/pixelcog/parallax.js/blob/master/LICENSE)
 */
!function(t,i,e,s){function o(i,e){var h=this;"object"==typeof e&&(delete e.refresh,delete e.render,t.extend(this,e)),this.$element=t(i),!this.imageSrc&&this.$element.is("img")&&(this.imageSrc=this.$element.attr("src"));var r=(this.position+"").toLowerCase().match(/\S+/g)||[];return r.length<1&&r.push("center"),1==r.length&&r.push(r[0]),("top"==r[0]||"bottom"==r[0]||"left"==r[1]||"right"==r[1])&&(r=[r[1],r[0]]),this.positionX!=s&&(r[0]=this.positionX.toLowerCase()),this.positionY!=s&&(r[1]=this.positionY.toLowerCase()),h.positionX=r[0],h.positionY=r[1],"left"!=this.positionX&&"right"!=this.positionX&&(this.positionX=isNaN(parseInt(this.positionX))?"center":parseInt(this.positionX)),"top"!=this.positionY&&"bottom"!=this.positionY&&(this.positionY=isNaN(parseInt(this.positionY))?"center":parseInt(this.positionY)),this.position=this.positionX+(isNaN(this.positionX)?"":"px")+" "+this.positionY+(isNaN(this.positionY)?"":"px"),navigator.userAgent.match(/(iPod|iPhone|iPad)/)?(this.iosFix&&!this.$element.is("img")&&this.$element.css({backgroundImage:"url("+this.imageSrc+")",backgroundSize:"cover",backgroundPosition:this.position}),this):navigator.userAgent.match(/(Android)/)?(this.androidFix&&!this.$element.is("img")&&this.$element.css({backgroundImage:"url("+this.imageSrc+")",backgroundSize:"cover",backgroundPosition:this.position}),this):(this.$mirror=t("<div />").prependTo("body"),this.$slider=t("<img />").prependTo(this.$mirror),this.$mirror.addClass("parallax-mirror").css({visibility:"hidden",zIndex:this.zIndex,position:"fixed",top:0,left:0,overflow:"hidden"}),this.$slider.addClass("parallax-slider").one("load",function(){h.naturalHeight&&h.naturalWidth||(h.naturalHeight=this.naturalHeight||this.height||1,h.naturalWidth=this.naturalWidth||this.width||1),h.aspectRatio=h.naturalWidth/h.naturalHeight,o.isSetup||o.setup(),o.sliders.push(h),o.isFresh=!1,o.requestRender()}),this.$slider[0].src=this.imageSrc,void((this.naturalHeight&&this.naturalWidth||this.$slider[0].complete)&&this.$slider.trigger("load")))}function h(s){return this.each(function(){var h=t(this),r="object"==typeof s&&s;this==i||this==e||h.is("body")?o.configure(r):h.data("px.parallax")||(r=t.extend({},h.data(),r),h.data("px.parallax",new o(this,r))),"string"==typeof s&&o[s]()})}!function(){for(var t=0,e=["ms","moz","webkit","o"],s=0;s<e.length&&!i.requestAnimationFrame;++s)i.requestAnimationFrame=i[e[s]+"RequestAnimationFrame"],i.cancelAnimationFrame=i[e[s]+"CancelAnimationFrame"]||i[e[s]+"CancelRequestAnimationFrame"];i.requestAnimationFrame||(i.requestAnimationFrame=function(e){var s=(new Date).getTime(),o=Math.max(0,16-(s-t)),h=i.setTimeout(function(){e(s+o)},o);return t=s+o,h}),i.cancelAnimationFrame||(i.cancelAnimationFrame=function(t){clearTimeout(t)})}(),t.extend(o.prototype,{speed:.2,bleed:0,zIndex:-100,iosFix:!0,androidFix:!0,position:"center",overScrollFix:!1,refresh:function(){this.boxWidth=this.$element.outerWidth(),this.boxHeight=this.$element.outerHeight()+2*this.bleed,this.boxOffsetTop=this.$element.offset().top-this.bleed,this.boxOffsetLeft=this.$element.offset().left,this.boxOffsetBottom=this.boxOffsetTop+this.boxHeight;var t=o.winHeight,i=o.docHeight,e=Math.min(this.boxOffsetTop,i-t),s=Math.max(this.boxOffsetTop+this.boxHeight-t,0),h=this.boxHeight+(e-s)*(1-this.speed)|0,r=(this.boxOffsetTop-e)*(1-this.speed)|0;if(h*this.aspectRatio>=this.boxWidth){this.imageWidth=h*this.aspectRatio|0,this.imageHeight=h,this.offsetBaseTop=r;var n=this.imageWidth-this.boxWidth;this.offsetLeft="left"==this.positionX?0:"right"==this.positionX?-n:isNaN(this.positionX)?-n/2|0:Math.max(this.positionX,-n)}else{this.imageWidth=this.boxWidth,this.imageHeight=this.boxWidth/this.aspectRatio|0,this.offsetLeft=0;var n=this.imageHeight-h;this.offsetBaseTop="top"==this.positionY?r:"bottom"==this.positionY?r-n:isNaN(this.positionY)?r-n/2|0:r+Math.max(this.positionY,-n)}},render:function(){var t=o.scrollTop,i=o.scrollLeft,e=this.overScrollFix?o.overScroll:0,s=t+o.winHeight;this.visibility=this.boxOffsetBottom>t&&this.boxOffsetTop<s?"visible":"hidden",this.mirrorTop=this.boxOffsetTop-t,this.mirrorLeft=this.boxOffsetLeft-i,this.offsetTop=this.offsetBaseTop-this.mirrorTop*(1-this.speed),this.$mirror.css({transform:"translate3d(0px, 0px, 0px)",visibility:this.visibility,top:this.mirrorTop-e,left:this.mirrorLeft,height:this.boxHeight,width:this.boxWidth}),this.$slider.css({transform:"translate3d(0px, 0px, 0px)",position:"absolute",top:this.offsetTop,left:this.offsetLeft,height:this.imageHeight,width:this.imageWidth,maxWidth:"none"})}}),t.extend(o,{scrollTop:0,scrollLeft:0,winHeight:0,winWidth:0,docHeight:1<<30,docWidth:1<<30,sliders:[],isReady:!1,isFresh:!1,isBusy:!1,setup:function(){if(!this.isReady){var s=t(e),h=t(i);h.on("resize.px.parallax load.px.parallax",function(){o.winHeight=h.height(),o.winWidth=h.width(),o.docHeight=s.height(),o.docWidth=s.width(),o.isFresh=!1,o.requestRender()}).on("scroll.px.parallax load.px.parallax",function(){var t=o.docHeight-o.winHeight,i=o.docWidth-o.winWidth;o.scrollTop=Math.max(0,Math.min(t,h.scrollTop())),o.scrollLeft=Math.max(0,Math.min(i,h.scrollLeft())),o.overScroll=Math.max(h.scrollTop()-t,Math.min(h.scrollTop(),0)),o.requestRender()}),this.isReady=!0}},configure:function(i){"object"==typeof i&&(delete i.refresh,delete i.render,t.extend(this.prototype,i))},refresh:function(){t.each(this.sliders,function(){this.refresh()}),this.isFresh=!0},render:function(){this.isFresh||this.refresh(),t.each(this.sliders,function(){this.render()})},requestRender:function(){var t=this;this.isBusy||(this.isBusy=!0,i.requestAnimationFrame(function(){t.render(),t.isBusy=!1}))}});var r=t.fn.parallax;t.fn.parallax=h,t.fn.parallax.Constructor=o,t.fn.parallax.noConflict=function(){return t.fn.parallax=r,this},t(e).on("ready.px.parallax.data-api",function(){t('[data-parallax="scroll"]').parallax()})}(jQuery,window,document);
/*!
 * classie - class helper functions
 * from bonzo https://github.com/ded/bonzo
 * 
 * classie.has( elem, 'my-class' ) -> true/false
 * classie.add( elem, 'my-new-class' )
 * classie.remove( elem, 'my-unwanted-class' )
 * classie.toggle( elem, 'my-class' )
 */
/*jshint browser: true, strict: true, undef: true */
/*global define: false */
( function( window ) {

'use strict';

// class helper functions from bonzo https://github.com/ded/bonzo

function classReg( className ) {
  return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
}

// classList support for class management
// altho to be fair, the api sucks because it won't accept multiple classes at once
var hasClass, addClass, removeClass;

if ( 'classList' in document.documentElement ) {
  hasClass = function( elem, c ) {
    return elem.classList.contains( c );
  };
  addClass = function( elem, c ) {
    elem.classList.add( c );
  };
  removeClass = function( elem, c ) {
    elem.classList.remove( c );
  };
}
else {
  hasClass = function( elem, c ) {
    return classReg( c ).test( elem.className );
  };
  addClass = function( elem, c ) {
    if ( !hasClass( elem, c ) ) {
      elem.className = elem.className + ' ' + c;
    }
  };
  removeClass = function( elem, c ) {
    elem.className = elem.className.replace( classReg( c ), ' ' );
  };
}

function toggleClass( elem, c ) {
  var fn = hasClass( elem, c ) ? removeClass : addClass;
  fn( elem, c );
}

var classie = {
  // full names
  hasClass: hasClass,
  addClass: addClass,
  removeClass: removeClass,
  toggleClass: toggleClass,
  // short names
  has: hasClass,
  add: addClass,
  remove: removeClass,
  toggle: toggleClass
};

// transport
if ( typeof define === 'function' && define.amd ) {
  // AMD
  define( classie );
} else {
  // browser global
  window.classie = classie;
}

})( window );
/**
 * main.js
 * http://www.codrops.com
 *
 * Licensed under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 * 
 * Copyright 2014, Codrops
 * http://www.codrops.com
 */
 (function() {

	var bodyEl = document.body,
		content = document.querySelector( '.gp-theprint-content-wrap-mobile' ),
		openbtn = document.getElementById( 'open-button' ),
		closebtn = document.getElementById( 'close-button' ),
		isOpen = false;

	function init() {
		initEvents();
	}

	function initEvents() {
		openbtn.addEventListener( 'click', toggleMenu );
		if( closebtn ) {
			closebtn.addEventListener( 'click', toggleMenu );
		}

		// close the menu element if the target it´s not the menu element or one of its descendants..
		content.addEventListener( 'click', function(ev) {
			var target = ev.target;
			if( isOpen && target !== openbtn ) {
				toggleMenu();
			}
		} );
	}

	function toggleMenu() {
		if( isOpen ) {
			classie.remove( bodyEl, 'show-menu' );
		}
		else {
			classie.add( bodyEl, 'show-menu' );
		}
		isOpen = !isOpen;
	}

	init();

})();