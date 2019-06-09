(window.webpackJsonp=window.webpackJsonp||[]).push([[6],{btsl:function(l,n,u){"use strict";u.r(n);var t=u("CcnG"),e=function(){return function(){}}(),o=u("pMnS"),s=u("Ip0R"),i=[{value:"emoticons",filePath:"assets/images/emoticons/src0.png"},{value:"xmas",filePath:"assets/images/xmas/src0.png"},{value:"animals",filePath:"assets/images/animals/src0.png"},{value:"flags",filePath:"assets/images/flags/src0.png"},{value:"food",filePath:"assets/images/food/src0.png"}],r=function(){function l(l){this.srcIndexes=[];for(var n=0;n<l;n++)this.srcIndexes.push(null);this.redCount=0,this.whiteCount=0}return l.prototype.clone=function(n){for(var u=new l(n),t=0;t<n;t++)u.srcIndexes[t]=this.srcIndexes[t];return u.redCount=this.redCount,u.whiteCount=this.whiteCount,u},l}(),a=function(){return function(){}}(),c=u("wSs+"),g=u("B43R"),h=u("doCK"),p=function(){function l(l,n,u){this.logService=l,this.utilsService=n,this.arrayUtilsService=u,this.target=[],this.src=[],this.prevGuesses=[],this.solutionLength=4,this.maxGuesses=10,this.sourceLength=8,this.iconSetDirectory="emoticons",this.baseUrl="assets/images/",this.guessIsComplete=!1,this.iconSets=i,this.setImagePaths()}return l.prototype.ngOnInit=function(){this.newGame()},Object.defineProperty(l.prototype,"gameComplete",{get:function(){return this.gameStatus.gameComplete},enumerable:!0,configurable:!0}),l.prototype.resetSource=function(){var l=""+this.baseUrl+this.iconSetDirectory+"/src";this.src=[];for(var n=0;n<this.sourceLength;++n){var u={id:"src"+n.toString(),filePath:l+n.toString()+".png"};this.src.push(u)}},l.prototype.cheat=function(l){for(var n=this.getTargetIndex(l),u=0;u<this.sourceLength;++u)if(this.src[u].filePath===this.solution[n]){this.target[n].filePath=this.src[u].filePath,this.guess.srcIndexes[n]=u;break}},l.prototype.resetTarget=function(){this.target=[];for(var l=0;l<this.solutionLength;++l){var n={id:"target"+l.toString(),filePath:this.blankImage};this.target.push(n)}},l.prototype.setImagePaths=function(){this.logService.info("baseUrl"+this.baseUrl),this.blankImage=this.baseUrl+"whitespot.png",this.logService.info(this.blankImage),this.greenTick=this.baseUrl+"greentick.png",this.amberTick=this.baseUrl+"ambertick.png"},l.prototype.onDragOver=function(l){l.stopPropagation(),l.preventDefault(),this.thetarget=l.srcElement.id},l.prototype.onDrop=function(l){l.preventDefault(),l.stopPropagation();var n=l.srcElement.id,u=Number(this.thetarget.substring(6));this.logService.debug("onDrop called with srcId: "+n+" , targetIndex "+u),this.updateGuess(n,u)},l.prototype.updateGuess=function(l,n){this.logService.debug("updateGuess called with srcId: "+l+" , targetIndex "+n);var u=this.getSrcIndex(l);this.duplicateDetected(u)||(this.guess.srcIndexes[n]=u,this.target[n].filePath=this.src[u].filePath)},l.prototype.checkGuessComplete=function(){this.guess.srcIndexes.some(function(l){return null===l})&&(this.guessIsComplete=!0),this.guessIsComplete=!1},l.prototype.srcImageClicked=function(l){if(this.logService.debug("srcImageClicked called with srcId: "+l),!this.gameStatus.gameComplete){var n=this.guess.srcIndexes.indexOf(null);n>-1&&this.updateGuess(l,n)}},l.prototype.targetImageClicked=function(l){if(!this.gameStatus.gameComplete){var n=this.getTargetIndex(l);this.guess.srcIndexes[n]=null,this.target[n].filePath=this.blankImage}},l.prototype.showPrevGuesses=function(){return h.a.ArrayHasValue(this.prevGuesses)},l.prototype.clearSolution=function(){this.logService.debug("clearSolution"),this.solution=[];for(var l=0;l<this.solutionLength;++l)this.solution.push("")},l.prototype.populateSolution=function(){var l=this;this.logService.debug("populateSolution");for(var n=0;n<this.solutionLength;++n)for(var u=!0,t=function(){var t=Math.floor(8*Math.random());e.solution.every(function(n){return n!==l.src[t].filePath})&&(e.solution[n]=e.src[t].filePath,u=!1)},e=this;u;)t()},l.prototype.duplicateDetected=function(l){var n=!1;return this.guess.srcIndexes.indexOf(l)>=0&&(n=!0),this.logService.debug("duplicateDetected returning "+n),n},l.prototype.getSrcIndex=function(l){return Number(l.substring(3))},l.prototype.getTargetIndex=function(l){return Number(l.substring(6))},l.prototype.processGuess=function(l){return this.checkGuess(),this.updatePreviousGuesses(),this.guess.redCount>=this.solutionLength?(this.gameStatus.playerHasWon=!0,void this.freezeGame()):this.prevGuesses.length>=this.maxGuesses?(this.gameStatus.playerHasLost=!0,void this.freezeGame()):(this.resetTarget(),void(this.guess=new r(this.solutionLength)))},l.prototype.checkGuess=function(){for(var l=0,n=0,u=function(u){var e=t.src[t.guess.srcIndexes[u]].filePath;e===t.solution[u]?l++:t.solution.some(function(l){return l===e})&&n++},t=this,e=0;e<this.solutionLength;++e)u(e);this.guess.redCount=l,this.guess.whiteCount=n},l.prototype.changeIconSet=function(l){l.value!==this.iconSetDirectory&&(this.iconSetDirectory=l.value,this.newGame())},l.prototype.updatePreviousGuesses=function(){var l=this.guess.clone(this.solutionLength);this.prevGuesses.unshift(l)},l.prototype.newGame=function(){this.logService.debug("newGame"),this.guess=new r(this.solutionLength),this.gameStatus=new a,this.prevGuesses=[],this.resetSource(),this.resetTarget(),this.clearSolution(),this.populateSolution()},l.prototype.freezeGame=function(){this.gameStatus.gameComplete=!0},l}(),b=t.mb({encapsulation:0,styles:[[".dropbox[_ngcontent-%COMP%]{width:40px;height:40px;padding:5px;border:1px solid #aaa}.well[_ngcontent-%COMP%]{padding:5px;border:1px solid #aaa}label[_ngcontent-%COMP%] > input[_ngcontent-%COMP%]{visibility:hidden;position:absolute}label[_ngcontent-%COMP%] > input[_ngcontent-%COMP%] + img[_ngcontent-%COMP%]{cursor:pointer;border:2px solid transparent}label[_ngcontent-%COMP%] > input[_ngcontent-%COMP%]:checked + img[_ngcontent-%COMP%]{border:2px solid red}"]],data:{}});function f(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,0,"img",[],[[8,"src",4],[8,"id",0],[8,"draggable",0]],[[null,"click"],[null,"ondragstart"]],function(l,n,u){var t=!0,e=l.component;return"click"===n&&(t=!1!==e.srcImageClicked(l.context.$implicit.id)&&t),"ondragstart"===n&&(t=!1!==e.onDragStart(u)&&t),t},null,null))],null,function(l,n){var u=n.component;l(n,2,0,t.qb(1,"",n.context.$implicit.filePath,""),t.qb(1,"",n.context.$implicit.id,""),!u.gameComplete)})}function d(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,0,"img",[["class","dropbox"],["draggable","false"]],[[8,"src",4],[8,"id",0]],[[null,"click"],[null,"onDrop"],[null,"ondragover"]],function(l,n,u){var t=!0,e=l.component;return"click"===n&&(t=!1!==e.targetImageClicked(l.context.$implicit.id)&&t),"onDrop"===n&&(t=!1!==e.onDrop(u)&&t),"ondragover"===n&&(t=!1!==e.onDragOver(u)&&t),t},null,null))],null,function(l,n){l(n,2,0,t.qb(1,"",n.context.$implicit.filePath,""),t.qb(1,"",n.context.$implicit.id,""))})}function m(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,0,"button",[["class","btn-default dropbox fa fa-question"]],[[8,"disabled",0]],[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==l.component.cheat(l.context.$implicit.id)&&t),t},null,null))],null,function(l,n){l(n,2,0,n.component.gameComplete)})}function v(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,0,"h1",[["class","fa fa-smile-o"]],null,null,null,null,null))],null,null)}function y(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,0,"h1",[["class","fa fa-frown-o"]],null,null,null,null,null))],null,null)}function x(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,0,"img",[["class","dropbox"]],[[8,"src",4],[8,"draggable",0]],null,null,null,null))],null,function(l,n){l(n,2,0,t.qb(1,"",n.context.$implicit,""),!1)})}function I(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,6,"div",[],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,v)),t.nb(2,16384,null,0,s.i,[t.O,t.L],{ngIf:[0,"ngIf"]},null),(l()(),t.fb(16777216,null,null,1,null,y)),t.nb(4,16384,null,0,s.i,[t.O,t.L],{ngIf:[0,"ngIf"]},null),(l()(),t.fb(16777216,null,null,1,null,x)),t.nb(6,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null)],function(l,n){var u=n.component;l(n,2,0,u.playerHasWon),l(n,4,0,u.playerHasLost),l(n,6,0,u.solution)},null)}function C(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,3,"span",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,2,"label",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,0,"input",[["name","iconset"],["type","radio"]],[[8,"value",0],[8,"checked",0]],[[null,"change"]],function(l,n,u){var t=!0;return"change"===n&&(t=!1!==l.component.changeIconSet(l.context.$implicit)&&t),t},null,null)),(l()(),t.ob(3,0,null,null,0,"img",[],[[8,"src",4]],null,null,null,null))],null,function(l,n){var u=n.component;l(n,2,0,t.qb(1,"",n.context.$implicit.value,""),n.context.$implicit.value==u.iconSetDirectory),l(n,3,0,t.qb(1,"",n.context.$implicit.filePath,""))})}function w(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,1,"td",[],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,0,"img",[],[[8,"src",4]],null,null,null,null))],null,function(l,n){l(n,1,0,t.qb(1,"",n.component.src[n.context.$implicit].filePath,""))})}function S(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,6,"tr",[],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,w)),t.nb(2,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null),(l()(),t.ob(3,0,null,null,1,"td",[],null,null,null,null,null)),(l()(),t.yb(4,null,["",""])),(l()(),t.ob(5,0,null,null,1,"td",[],null,null,null,null,null)),(l()(),t.yb(6,null,["",""]))],function(l,n){l(n,2,0,n.context.$implicit.srcIndexes)},function(l,n){l(n,4,0,n.context.$implicit.redCount),l(n,6,0,n.context.$implicit.whiteCount)})}function O(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,10,"div",[["class","table table-striped"]],null,null,null,null,null)),(l()(),t.ob(1,0,null,null,6,"thead",[],null,null,null,null,null)),(l()(),t.ob(2,0,null,null,1,"th",[["colspan","4"]],null,null,null,null,null)),(l()(),t.ob(3,0,null,null,0,"span",[["class","fa fa-bars"]],null,null,null,null,null)),(l()(),t.ob(4,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),t.ob(5,0,null,null,0,"img",[],[[8,"src",4]],null,null,null,null)),(l()(),t.ob(6,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),t.ob(7,0,null,null,0,"img",[],[[8,"src",4]],null,null,null,null)),(l()(),t.ob(8,0,null,null,2,"tbody",[],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,S)),t.nb(10,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null)],function(l,n){l(n,10,0,n.component.prevGuesses)},function(l,n){var u=n.component;l(n,5,0,t.qb(1,"",u.greenTick,"")),l(n,7,0,t.qb(1,"",u.amberTick,""))})}function k(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,1,"h1",[],null,null,null,null,null)),(l()(),t.yb(-1,null,["Decoder"])),(l()(),t.ob(2,0,null,null,30,"div",[["class","row"]],null,null,null,null,null)),(l()(),t.ob(3,0,null,null,0,"div",[["class","col-lg-1 col-lg-offset-2 col-md-4 col-md-offset-1"]],null,null,null,null,null)),(l()(),t.ob(4,0,null,null,25,"div",[["class","well well-lg col-lg-4 col-lg-offset-2 col-md-4 col-md-offset-2"]],null,null,null,null,null)),(l()(),t.ob(5,0,null,null,2,"div",[["class"," fa fa-hand-paper-o"]],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,f)),t.nb(7,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null),(l()(),t.ob(8,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(9,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(10,0,null,null,4,"div",[["class","fa fa-hand-o-right"]],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,d)),t.nb(12,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null),(l()(),t.ob(13,0,null,null,1,"button",[["class","btn-primary dropbox"]],[[8,"disabled",0]],[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==l.component.processGuess(u)&&t),t},null,null)),(l()(),t.ob(14,0,null,null,0,"span",[["class","fa fa-check-square-o"]],null,null,null,null,null)),(l()(),t.ob(15,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(16,0,null,null,2,"div",[["class"," fa fa-life-ring"]],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,m)),t.nb(18,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null),(l()(),t.ob(19,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(20,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,I)),t.nb(22,16384,null,0,s.i,[t.O,t.L],{ngIf:[0,"ngIf"]},null),(l()(),t.ob(23,0,null,null,2,"div",[],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,C)),t.nb(25,278528,null,0,s.h,[t.O,t.L,t.s],{ngForOf:[0,"ngForOf"]},null),(l()(),t.ob(26,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(27,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(28,0,null,null,1,"button",[["class","btn-primary"]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==l.component.newGame()&&t),t},null,null)),(l()(),t.ob(29,0,null,null,0,"span",[["class","fa fa-reply"]],null,null,null,null,null)),(l()(),t.ob(30,0,null,null,2,"div",[["class","col-lg-4"]],null,null,null,null,null)),(l()(),t.fb(16777216,null,null,1,null,O)),t.nb(32,16384,null,0,s.i,[t.O,t.L],{ngIf:[0,"ngIf"]},null),(l()(),t.ob(33,0,null,null,0,"br",[],null,null,null,null,null)),(l()(),t.ob(34,0,null,null,9,"div",[],null,null,null,null,null)),(l()(),t.yb(-1,null,["Icons made by "])),(l()(),t.ob(36,0,null,null,1,"a",[["href","http://www.freepik.com"],["title","Freepik"]],null,null,null,null,null)),(l()(),t.yb(-1,null,["Freepik"])),(l()(),t.yb(-1,null,[" from "])),(l()(),t.ob(39,0,null,null,1,"a",[["href","https://www.flaticon.com/"],["title","Flaticon"]],null,null,null,null,null)),(l()(),t.yb(-1,null,["www.flaticon.com"])),(l()(),t.yb(-1,null,[" is licensed by "])),(l()(),t.ob(42,0,null,null,1,"a",[["href","http://creativecommons.org/licenses/by/3.0/"],["target","_blank"],["title","Creative Commons BY 3.0"]],null,null,null,null,null)),(l()(),t.yb(-1,null,["CC 3.0 BY"]))],function(l,n){var u=n.component;l(n,7,0,u.src),l(n,12,0,u.target),l(n,18,0,u.target),l(n,22,0,u.gameComplete),l(n,25,0,u.iconSets),l(n,32,0,u.showPrevGuesses())},function(l,n){l(n,13,0,n.component.guessIsComplete)})}function P(l){return t.zb(0,[(l()(),t.ob(0,0,null,null,1,"app-decoder",[],null,[[null,"dragenter"],[null,"dragover"],[null,"dragend"]],function(l,n,u){var e=!0;return"dragenter"===n&&(e=!1!==t.wb(l,1).onDragOver(u)&&e),"dragover"===n&&(e=!1!==t.wb(l,1).onDragOver(u)&&e),"dragend"===n&&(e=!1!==t.wb(l,1).onDrop(u)&&e),e},k,b)),t.nb(1,114688,null,0,p,[c.a,g.a,h.a],null,null)],function(l,n){l(n,1,0)},null)}var G=t.kb("app-decoder",p,P,{},{},[]),L=u("ZYCi"),D=function(){return function(){}}();u.d(n,"DecoderModuleNgFactory",function(){return F});var F=t.lb(e,[],function(l){return t.ub([t.vb(512,t.j,t.ab,[[8,[o.a,G]],[3,t.j],t.x]),t.vb(4608,s.k,s.j,[t.u,[2,s.q]]),t.vb(1073742336,s.b,s.b,[]),t.vb(1073742336,L.m,L.m,[[2,L.s],[2,L.k]]),t.vb(1073742336,D,D,[]),t.vb(1073742336,e,e,[]),t.vb(1024,L.i,function(){return[[{path:"",component:p}]]},[])])})}}]);