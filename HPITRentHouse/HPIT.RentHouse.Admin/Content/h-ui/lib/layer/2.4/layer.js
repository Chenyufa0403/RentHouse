/*! layer-v3.0 弹层组件 License LGPL  http://layer.layui.com/ By 贤心 */
;!function(a,b){"use strict";var c,d,e={getPath:function(){var a=document.scripts,b=a[a.length-1],c=b.src;if(!b.getAttribute("merge"))return c.substring(0,c.lastIndexOf("/")+1)}(),enter:function(a){13===a.keyCode&&a.preventDefault()},config:{},end:{},btn:["&#x786E;&#x5B9A;","&#x53D6;&#x6D88;"],type:["dialog","page","iframe","loading","tips"]},f={v:"2.4",ie6:!!a.ActiveXObject&&!a.XMLHttpRequest,index:0,path:e.getPath,config:function(a,b){var d=0;return a=a||{},f.cache=e.config=c.extend(e.config,a),f.path=e.config.path||f.path,"string"==typeof a.extend&&(a.extend=[a.extend]),f.use("skin/layer.css"/*tpa=http://demo.h-ui.net/H-ui.admin.page/lib/layer/2.4/skin/layer.css*/,a.extend&&a.extend.length>0?function g(){var c=a.extend;f.use(c[c[d]?d:d-1],d<c.length?function(){return++d,g}():b)}():b),this},use:function(a,b,d){var e=c("head")[0],a=a.replace(/\s/g,""),g=/\.css$/.test(a),h=document.createElement(g?"link":"script"),i="layui_layer_"+a.replace(/\.|\//g,"");return f.path?(g&&(h.rel="stylesheet"),h[g?"href":"src"]=/^http:\/\//.test(a)?a:f.path+a,h.id=i,c("#"+i)[0]||e.appendChild(h),function j(){(g?1989===parseInt(c("#"+i).css("width")):f[d||i])?function(){b&&b();try{g||e.removeChild(h)}catch(a){}}():setTimeout(j,100)}(),this):void 0},ready:function(a,b){var d="function"==typeof a;return d&&(b=a),f.config(c.extend(e.config,function(){return d?{}:{path:a}}()),b),this},alert:function(a,b,d){var e="function"==typeof b;return e&&(d=b),f.open(c.extend({content:a,yes:d},e?{}:b))},confirm:function(a,b,d,g){var h="function"==typeof b;return h&&(g=d,d=b),f.open(c.extend({content:a,btn:e.btn,yes:d,btn2:g},h?{}:b))},msg:function(a,d,g){var i="function"==typeof d,j=e.config.skin,k=(j?j+" "+j+"-msg":"")||"layui-layer-msg",l=h.anim.length-1;return i&&(g=d),f.open(c.extend({content:a,time:3e3,shade:!1,skin:k,title:!1,closeBtn:!1,btn:!1,end:g},i&&!e.config.skin?{skin:k+" layui-layer-hui",shift:l}:function(){return d=d||{},(-1===d.icon||d.icon===b&&!e.config.skin)&&(d.skin=k+" "+(d.skin||"layui-layer-hui")),d}()))},load:function(a,b){return f.open(c.extend({type:3,icon:a||0,shade:.01},b))},tips:function(a,b,d){return f.open(c.extend({type:4,content:[a,b],closeBtn:!1,time:3e3,shade:!1,fix:!1,maxWidth:210},d))}},g=function(a){var b=this;b.index=++f.index,b.config=c.extend({},b.config,e.config,a),b.creat()};g.pt=g.prototype;var h=["layui-layer",".layui-layer-title",".layui-layer-main",".layui-layer-dialog","layui-layer-iframe","layui-layer-content","layui-layer-btn","layui-layer-close"];h.anim=["layer-anim","layer-anim-01","layer-anim-02","layer-anim-03","layer-anim-04","layer-anim-05","layer-anim-06"],g.pt.config={type:0,shade:.3,fix:!0,move:h[1],title:"&#x4FE1;&#x606F;",offset:"auto",area:"auto",closeBtn:1,time:0,zIndex:19891014,maxWidth:360,shift:0,icon:-1,scrollbar:!0,tips:2},g.pt.vessel=function(a,b){var c=this,d=c.index,f=c.config,g=f.zIndex+d,i="object"==typeof f.title,j=f.maxmin&&(1===f.type||2===f.type),k=f.title?'<div class="layui-layer-title" style="'+(i?f.title[1]:"")+'">'+(i?f.title[0]:f.title)+"</div>":"";return f.zIndex=g,b([f.shade?'<div class="layui-layer-shade" id="layui-layer-shade'+d+'" times="'+d+'" style="'+("z-index:"+(g-1)+"; background-color:"+(f.shade[1]||"#000")+"; opacity:"+(f.shade[0]||f.shade)+"; filter:alpha(opacity="+(100*f.shade[0]||100*f.shade)+");")+'"></div>':"",'<div class="'+h[0]+(" layui-layer-"+e.type[f.type])+(0!=f.type&&2!=f.type||f.shade?"":" layui-layer-border")+" "+(f.skin||"")+'" id="'+h[0]+d+'" type="'+e.type[f.type]+'" times="'+d+'" showtime="'+f.time+'" conType="'+(a?"object":"string")+'" style="z-index: '+g+"; width:"+f.area[0]+";height:"+f.area[1]+(f.fix?"":";position:absolute;")+'">'+(a&&2!=f.type?"":k)+'<div id="'+(f.id||"")+'" class="layui-layer-content'+(0==f.type&&-1!==f.icon?" layui-layer-padding":"")+(3==f.type?" layui-layer-loading"+f.icon:"")+'">'+(0==f.type&&-1!==f.icon?'<i class="layui-layer-ico layui-layer-ico'+f.icon+'"></i>':"")+(1==f.type&&a?"":f.content||"")+'</div><span class="layui-layer-setwin">'+function(){var a=j?'<a class="layui-layer-min" href="javascript:;"><cite></cite></a><a class="layui-layer-ico layui-layer-max" href="javascript:;"></a>':"";return f.closeBtn&&(a+='<a class="layui-layer-ico '+h[7]+" "+h[7]+(f.title?f.closeBtn:4==f.type?"1":"2")+'" href="javascript:;"></a>'),a}()+"</span>"+(f.btn?function(){var a="";"string"==typeof f.btn&&(f.btn=[f.btn]);for(var b=0,c=f.btn.length;c>b;b++)a+='<a class="'+h[6]+b+'">'+f.btn[b]+"</a>";return'<div class="'+h[6]+'">'+a+"</div>"}():"")+"</div>"],k),c},g.pt.creat=function(){var a=this,b=a.config,g=a.index,i=b.content,j="object"==typeof i;if(!c("#"+b.id)[0]){switch("string"==typeof b.area&&(b.area="auto"===b.area?["",""]:[b.area,""]),b.type){case 0:b.btn="btn"in b?b.btn:e.btn[0],f.closeAll("dialog");break;case 2:var i=b.content=j?b.content:[b.content||"http://layer.layui.com/","auto"];b.content='<iframe scrolling="'+(b.content[1]||"auto")+'" allowtransparency="true" id="'+h[4]+g+'" name="'+h[4]+g+'" onload="this.className=\'\';" class="layui-layer-load" frameborder="0" src="'+b.content[0]+'"></iframe>';break;case 3:b.title=!1,b.closeBtn=!1,-1===b.icon&&0===b.icon,f.closeAll("loading");break;case 4:j||(b.content=[b.content,"body"]),b.follow=b.content[1],b.content=b.content[0]+'<i class="layui-layer-TipsG"></i>',b.title=!1,b.tips="object"==typeof b.tips?b.tips:[b.tips,!0],b.tipsMore||f.closeAll("tips")}a.vessel(j,function(d,e){c("body").append(d[0]),j?function(){2==b.type||4==b.type?function(){c("body").append(d[1])}():function(){i.parents("."+h[0])[0]||(i.show().addClass("layui-layer-wrap").wrap(d[1]),c("#"+h[0]+g).find("."+h[5]).before(e))}()}():c("body").append(d[1]),a.layero=c("#"+h[0]+g),b.scrollbar||h.html.css("overflow","hidden").attr("layer-full",g)}).auto(g),2==b.type&&f.ie6&&a.layero.find("iframe").attr("src",i[0]),c(document).off("keydown",e.enter).on("keydown",e.enter),a.layero.on("keydown",function(a){c(document).off("keydown",e.enter)}),4==b.type?a.tips():a.offset(),b.fix&&d.on("resize",function(){a.offset(),(/^\d+%$/.test(b.area[0])||/^\d+%$/.test(b.area[1]))&&a.auto(g),4==b.type&&a.tips()}),b.time<=0||setTimeout(function(){f.close(a.index)},b.time),a.move().callback(),h.anim[b.shift]&&a.layero.addClass(h.anim[b.shift])}},g.pt.auto=function(a){function b(a){a=g.find(a),a.height(i[1]-j-k-2*(0|parseFloat(a.css("padding"))))}var e=this,f=e.config,g=c("#"+h[0]+a);""===f.area[0]&&f.maxWidth>0&&(/MSIE 7/.test(navigator.userAgent)&&f.btn&&g.width(g.innerWidth()),g.outerWidth()>f.maxWidth&&g.width(f.maxWidth));var i=[g.innerWidth(),g.innerHeight()],j=g.find(h[1]).outerHeight()||0,k=g.find("."+h[6]).outerHeight()||0;switch(f.type){case 2:b("iframe");break;default:""===f.area[1]?f.fix&&i[1]>=d.height()&&(i[1]=d.height(),b("."+h[5])):b("."+h[5])}return e},g.pt.offset=function(){var a=this,b=a.config,c=a.layero,e=[c.outerWidth(),c.outerHeight()],f="object"==typeof b.offset;a.offsetTop=(d.height()-e[1])/2,a.offsetLeft=(d.width()-e[0])/2,f?(a.offsetTop=b.offset[0],a.offsetLeft=b.offset[1]||a.offsetLeft):"auto"!==b.offset&&(a.offsetTop=b.offset,"rb"===b.offset&&(a.offsetTop=d.height()-e[1],a.offsetLeft=d.width()-e[0])),b.fix||(a.offsetTop=/%$/.test(a.offsetTop)?d.height()*parseFloat(a.offsetTop)/100:parseFloat(a.offsetTop),a.offsetLeft=/%$/.test(a.offsetLeft)?d.width()*parseFloat(a.offsetLeft)/100:parseFloat(a.offsetLeft),a.offsetTop+=d.scrollTop(),a.offsetLeft+=d.scrollLeft()),c.css({top:a.offsetTop,left:a.offsetLeft})},g.pt.tips=function(){var a=this,b=a.config,e=a.layero,f=[e.outerWidth(),e.outerHeight()],g=c(b.follow);g[0]||(g=c("body"));var i={width:g.outerWidth(),height:g.outerHeight(),top:g.offset().top,left:g.offset().left},j=e.find(".layui-layer-TipsG"),k=b.tips[0];b.tips[1]||j.remove(),i.autoLeft=function(){i.left+f[0]-d.width()>0?(i.tipLeft=i.left+i.width-f[0],j.css({right:12,left:"auto"})):i.tipLeft=i.left},i.where=[function(){i.autoLeft(),i.tipTop=i.top-f[1]-10,j.removeClass("layui-layer-TipsB").addClass("layui-layer-TipsT").css("border-right-color",b.tips[1])},function(){i.tipLeft=i.left+i.width+10,i.tipTop=i.top,j.removeClass("layui-layer-TipsL").addClass("layui-layer-TipsR").css("border-bottom-color",b.tips[1])},function(){i.autoLeft(),i.tipTop=i.top+i.height+10,j.removeClass("layui-layer-TipsT").addClass("layui-layer-TipsB").css("border-right-color",b.tips[1])},function(){i.tipLeft=i.left-f[0]-10,i.tipTop=i.top,j.removeClass("layui-layer-TipsR").addClass("layui-layer-TipsL").css("border-bottom-color",b.tips[1])}],i.where[k-1](),1===k?i.top-(d.scrollTop()+f[1]+16)<0&&i.where[2]():2===k?d.width()-(i.left+i.width+f[0]+16)>0||i.where[3]():3===k?i.top-d.scrollTop()+i.height+f[1]+16-d.height()>0&&i.where[0]():4===k&&f[0]+16-i.left>0&&i.where[1](),e.find("."+h[5]).css({"background-color":b.tips[1],"padding-right":b.closeBtn?"30px":""}),e.css({left:i.tipLeft-(b.fix?d.scrollLeft():0),top:i.tipTop-(b.fix?d.scrollTop():0)})},g.pt.move=function(){var a=this,b=a.config,e={setY:0,moveLayer:function(){var a=e.layero,b=parseInt(a.css("margin-left")),c=parseInt(e.move.css("left"));0===b||(c-=b),"fixed"!==a.css("position")&&(c-=a.parent().offset().left,e.setY=0),a.css({left:c,top:parseInt(e.move.css("top"))-e.setY})}},f=a.layero.find(b.move);return b.move&&f.attr("move","ok"),f.css({cursor:b.move?"move":"auto"}),c(b.move).on("mousedown",function(a){if(a.preventDefault(),"ok"===c(this).attr("move")){e.ismove=!0,e.layero=c(this).parents("."+h[0]);var f=e.layero.offset().left,g=e.layero.offset().top,i=e.layero.outerWidth()-6,j=e.layero.outerHeight()-6;c("#layui-layer-moves")[0]||c("body").append('<div id="layui-layer-moves" class="layui-layer-moves" style="left:'+f+"px; top:"+g+"px; width:"+i+"px; height:"+j+'px; z-index:2147483584"></div>'),e.move=c("#layui-layer-moves"),b.moveType&&e.move.css({visibility:"hidden"}),e.moveX=a.pageX-e.move.position().left,e.moveY=a.pageY-e.move.position().top,"fixed"!==e.layero.css("position")||(e.setY=d.scrollTop())}}),c(document).mousemove(function(a){if(e.ismove){var c=a.pageX-e.moveX,f=a.pageY-e.moveY;if(a.preventDefault(),!b.moveOut){e.setY=d.scrollTop();var g=d.width()-e.move.outerWidth(),h=e.setY;0>c&&(c=0),c>g&&(c=g),h>f&&(f=h),f>d.height()-e.move.outerHeight()+e.setY&&(f=d.height()-e.move.outerHeight()+e.setY)}e.move.css({left:c,top:f}),b.moveType&&e.moveLayer(),c=f=g=h=null}}).mouseup(function(){try{e.ismove&&(e.moveLayer(),e.move.remove(),b.moveEnd&&b.moveEnd()),e.ismove=!1}catch(a){e.ismove=!1}}),a},g.pt.callback=function(){function a(){var a=g.cancel&&g.cancel(b.index,d);a===!1||f.close(b.index)}var b=this,d=b.layero,g=b.config;b.openLayer(),g.success&&(2==g.type?d.find("iframe").on("load",function(){g.success(d,b.index)}):g.success(d,b.index)),f.ie6&&b.IE6(d),d.find("."+h[6]).children("a").on("click",function(){var a=c(this).index();if(0===a)g.yes?g.yes(b.index,d):g.btn1?g.btn1(b.index,d):f.close(b.index);else{var e=g["btn"+(a+1)]&&g["btn"+(a+1)](b.index,d);e===!1||f.close(b.index)}}),d.find("."+h[7]).on("click",a),g.shadeClose&&c("#layui-layer-shade"+b.index).on("click",function(){f.close(b.index)}),d.find(".layui-layer-min").on("click",function(){var a=g.min&&g.min(d);a===!1||f.min(b.index,g)}),d.find(".layui-layer-max").on("click",function(){c(this).hasClass("layui-layer-maxmin")?(f.restore(b.index),g.restore&&g.restore(d)):(f.full(b.index,g),setTimeout(function(){g.full&&g.full(d)},100))}),g.end&&(e.end[b.index]=g.end)},e.reselect=function(){c.each(c("select"),function(a,b){var d=c(this);d.parents("."+h[0])[0]||1==d.attr("layer")&&c("."+h[0]).length<1&&d.removeAttr("layer").show(),d=null})},g.pt.IE6=function(a){function b(){a.css({top:f+(e.config.fix?d.scrollTop():0)})}var e=this,f=a.offset().top;b(),d.scroll(b),c("select").each(function(a,b){var d=c(this);d.parents("."+h[0])[0]||"none"===d.css("display")||d.attr({layer:"1"}).hide(),d=null})},g.pt.openLayer=function(){var a=this;f.zIndex=a.config.zIndex,f.setTop=function(a){var b=function(){f.zIndex++,a.css("z-index",f.zIndex+1)};return f.zIndex=parseInt(a[0].style.zIndex),a.on("mousedown",b),f.zIndex}},e.record=function(a){var b=[a.width(),a.height(),a.position().top,a.position().left+parseFloat(a.css("margin-left"))];a.find(".layui-layer-max").addClass("layui-layer-maxmin"),a.attr({area:b})},e.rescollbar=function(a){h.html.attr("layer-full")==a&&(h.html[0].style.removeProperty?h.html[0].style.removeProperty("overflow"):h.html[0].style.removeAttribute("overflow"),h.html.removeAttr("layer-full"))},a.layer=f,f.getChildFrame=function(a,b){return b=b||c("."+h[4]).attr("times"),c("#"+h[0]+b).find("iframe").contents().find(a)},f.getFrameIndex=function(a){return c("#"+a).parents("."+h[4]).attr("times")},f.iframeAuto=function(a){if(a){var b=f.getChildFrame("html",a).outerHeight(),d=c("#"+h[0]+a),e=d.find(h[1]).outerHeight()||0,g=d.find("."+h[6]).outerHeight()||0;d.css({height:b+e+g}),d.find("iframe").css({height:b})}},f.iframeSrc=function(a,b){c("#"+h[0]+a).find("iframe").attr("src",b)},f.style=function(a,b){var d=c("#"+h[0]+a),f=d.attr("type"),g=d.find(h[1]).outerHeight()||0,i=d.find("."+h[6]).outerHeight()||0;(f===e.type[1]||f===e.type[2])&&(d.css(b),f===e.type[2]&&d.find("iframe").css({height:parseFloat(b.height)-g-i}))},f.min=function(a,b){var d=c("#"+h[0]+a),g=d.find(h[1]).outerHeight()||0;e.record(d),f.style(a,{width:180,height:g,overflow:"hidden"}),d.find(".layui-layer-min").hide(),"page"===d.attr("type")&&d.find(h[4]).hide(),e.rescollbar(a)},f.restore=function(a){var b=c("#"+h[0]+a),d=b.attr("area").split(",");b.attr("type");f.style(a,{width:parseFloat(d[0]),height:parseFloat(d[1]),top:parseFloat(d[2]),left:parseFloat(d[3]),overflow:"visible"}),b.find(".layui-layer-max").removeClass("layui-layer-maxmin"),b.find(".layui-layer-min").show(),"page"===b.attr("type")&&b.find(h[4]).show(),e.rescollbar(a)},f.full=function(a){var b,g=c("#"+h[0]+a);e.record(g),h.html.attr("layer-full")||h.html.css("overflow","hidden").attr("layer-full",a),clearTimeout(b),b=setTimeout(function(){var b="fixed"===g.css("position");f.style(a,{top:b?0:d.scrollTop(),left:b?0:d.scrollLeft(),width:d.width(),height:d.height()}),g.find(".layui-layer-min").hide()},100)},f.title=function(a,b){var d=c("#"+h[0]+(b||f.index)).find(h[1]);d.html(a)},f.close=function(a){var b=c("#"+h[0]+a),d=b.attr("type");if(b[0]){if(d===e.type[1]&&"object"===b.attr("conType")){b.children(":not(."+h[5]+")").remove();for(var g=0;2>g;g++)b.find(".layui-layer-wrap").unwrap().hide()}else{if(d===e.type[2])try{var i=c("#"+h[4]+a)[0];i.contentWindow.document.write(""),i.contentWindow.close(),b.find("."+h[5])[0].removeChild(i)}catch(j){}b[0].innerHTML="",b.remove()}c("#layui-layer-moves, #layui-layer-shade"+a).remove(),f.ie6&&e.reselect(),e.rescollbar(a),c(document).off("keydown",e.enter),"function"==typeof e.end[a]&&e.end[a](),delete e.end[a]}},f.closeAll=function(a){c.each(c("."+h[0]),function(){var b=c(this),d=a?b.attr("type")===a:1;d&&f.close(b.attr("times")),d=null})};var i=f.cache||{},j=function(a){return i.skin?" "+i.skin+" "+i.skin+"-"+a:""};f.prompt=function(a,b){a=a||{},"function"==typeof a&&(b=a);var d,e=2==a.formType?'<textarea class="layui-layer-input">'+(a.value||"")+"</textarea>":function(){return'<input type="'+(1==a.formType?"password":"text")+'" class="layui-layer-input" value="'+(a.value||"")+'">'}();return f.open(c.extend({btn:["&#x786E;&#x5B9A;","&#x53D6;&#x6D88;"],content:e,skin:"layui-layer-prompt"+j("prompt"),success:function(a){d=a.find(".layui-layer-input"),d.focus()},yes:function(c){var e=d.val();""===e?d.focus():e.length>(a.maxlength||500)?f.tips("&#x6700;&#x591A;&#x8F93;&#x5165;"+(a.maxlength||500)+"&#x4E2A;&#x5B57;&#x6570;",d,{tips:1}):b&&b(e,c,d)}},a))},f.tab=function(a){a=a||{};var b=a.tab||{};return f.open(c.extend({type:1,skin:"layui-layer-tab"+j("tab"),title:function(){var a=b.length,c=1,d="";if(a>0)for(d='<span class="layui-layer-tabnow">'+b[0].title+"</span>";a>c;c++)d+="<span>"+b[c].title+"</span>";return d}(),content:'<ul class="layui-layer-tabmain">'+function(){var a=b.length,c=1,d="";if(a>0)for(d='<li class="layui-layer-tabli xubox_tab_layer">'+(b[0].content||"no content")+"</li>";a>c;c++)d+='<li class="layui-layer-tabli">'+(b[c].content||"no  content")+"</li>";return d}()+"</ul>",success:function(b){var d=b.find(".layui-layer-title").children(),e=b.find(".layui-layer-tabmain").children();d.on("mousedown",function(b){b.stopPropagation?b.stopPropagation():b.cancelBubble=!0;var d=c(this),f=d.index();d.addClass("layui-layer-tabnow").siblings().removeClass("layui-layer-tabnow"),e.eq(f).show().siblings().hide(),"function"==typeof a.change&&a.change(f)})}},a))},f.photos=function(b,d,e){function g(a,b,c){var d=new Image;return d.src=a,d.complete?b(d):(d.onload=function(){d.onload=null,b(d)},void(d.onerror=function(a){d.onerror=null,c(a)}))}var h={};if(b=b||{},b.photos){var i=b.photos.constructor===Object,k=i?b.photos:{},l=k.data||[],m=k.start||0;if(h.imgIndex=(0|m)+1,b.img=b.img||"img",i){if(0===l.length)return f.msg("&#x6CA1;&#x6709;&#x56FE;&#x7247;")}else{var n=c(b.photos),o=function(){l=[],n.find(b.img).each(function(a){var b=c(this);b.attr("layer-index",a),l.push({alt:b.attr("alt"),pid:b.attr("layer-pid"),src:b.attr("layer-src")||b.attr("src"),thumb:b.attr("src")})})};if(o(),0===l.length)return;if(d||n.on("click",b.img,function(){var a=c(this),d=a.attr("layer-index");f.photos(c.extend(b,{photos:{start:d,data:l,tab:b.tab},full:b.full}),!0),o()}),!d)return}h.imgprev=function(a){h.imgIndex--,h.imgIndex<1&&(h.imgIndex=l.length),h.tabimg(a)},h.imgnext=function(a,b){h.imgIndex++,h.imgIndex>l.length&&(h.imgIndex=1,b)||h.tabimg(a)},h.keyup=function(a){if(!h.end){var b=a.keyCode;a.preventDefault(),37===b?h.imgprev(!0):39===b?h.imgnext(!0):27===b&&f.close(h.index)}},h.tabimg=function(a){l.length<=1||(k.start=h.imgIndex-1,f.close(h.index),f.photos(b,!0,a))},h.event=function(){h.bigimg.hover(function(){h.imgsee.show()},function(){h.imgsee.hide()}),h.bigimg.find(".layui-layer-imgprev").on("click",function(a){a.preventDefault(),h.imgprev()}),h.bigimg.find(".layui-layer-imgnext").on("click",function(a){a.preventDefault(),h.imgnext()}),c(document).on("keyup",h.keyup)},h.loadi=f.load(1,{shade:"shade"in b?!1:.9,scrollbar:!1}),g(l[m].src,function(d){f.close(h.loadi),h.index=f.open(c.extend({type:1,area:function(){var e=[d.width,d.height],f=[c(a).width()-50,c(a).height()-50];return!b.full&&e[0]>f[0]&&(e[0]=f[0],e[1]=e[0]*d.height/d.width),[e[0]+"px",e[1]+"px"]}(),title:!1,shade:.9,shadeClose:!0,closeBtn:!1,move:".layui-layer-phimg img",moveType:1,scrollbar:!1,moveOut:!0,shift:5*Math.random()|0,skin:"layui-layer-photos"+j("photos"),content:'<div class="layui-layer-phimg"><img src="'+l[m].src+'" alt="'+(l[m].alt||"")+'" layer-pid="'+l[m].pid+'"><div class="layui-layer-imgsee">'+(l.length>1?'<span class="layui-layer-imguide"><a href="javascript:;" class="layui-layer-iconext layui-layer-imgprev"></a><a href="javascript:;" class="layui-layer-iconext layui-layer-imgnext"></a></span>':"")+'<div class="layui-layer-imgbar" style="display:'+(e?"block":"")+'"><span class="layui-layer-imgtit"><a href="javascript:;">'+(l[m].alt||"")+"</a><em>"+h.imgIndex+"/"+l.length+"</em></span></div></div></div>",success:function(a,c){h.bigimg=a.find(".layui-layer-phimg"),h.imgsee=a.find(".layui-layer-imguide,.layui-layer-imgbar"),h.event(a),b.tab&&b.tab(l[m],a)},end:function(){h.end=!0,c(document).off("keyup",h.keyup)}},b))},function(){f.close(h.loadi),f.msg("&#x5F53;&#x524D;&#x56FE;&#x7247;&#x5730;&#x5740;&#x5F02;&#x5E38;<br>&#x662F;&#x5426;&#x7EE7;&#x7EED;&#x67E5;&#x770B;&#x4E0B;&#x4E00;&#x5F20;&#xFF1F;",{time:3e4,btn:["&#x4E0B;&#x4E00;&#x5F20;","&#x4E0D;&#x770B;&#x4E86;"],yes:function(){l.length>1&&h.imgnext(!0,!0)}})})}},e.run=function(){c=jQuery,d=c(a),h.html=c("html"),f.open=function(a){var b=new g(a);return b.index}},"function"==typeof define?define(function(){return e.run(),f}):function(){e.run(),f.use("skin/layer.css"/*tpa=http://demo.h-ui.net/H-ui.admin.page/lib/layer/2.4/skin/layer.css*/)}()}(window);