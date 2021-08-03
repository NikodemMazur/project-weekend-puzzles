"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[637],{3905:function(e,t,n){n.d(t,{Zo:function(){return s},kt:function(){return h}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function u(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var l=r.createContext({}),d=function(e){var t=r.useContext(l),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},s=function(e){var t=d(e.components);return r.createElement(l.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},c=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,l=e.parentName,s=u(e,["components","mdxType","originalType","parentName"]),c=d(n),h=o,m=c["".concat(l,".").concat(h)]||c[h]||p[h]||i;return n?r.createElement(m,a(a({ref:t},s),{},{components:n})):r.createElement(m,a({ref:t},s))}));function h(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=c;var u={};for(var l in t)hasOwnProperty.call(t,l)&&(u[l]=t[l]);u.originalType=e,u.mdxType="string"==typeof e?e:o,a[1]=u;for(var d=2;d<i;d++)a[d]=n[d];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}c.displayName="MDXCreateElement"},4923:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return u},metadata:function(){return l},toc:function(){return d},default:function(){return p}});var r=n(7462),o=n(3366),i=(n(7294),n(3905)),a=["components"],u={sidebar_position:2},l={unversionedId:"getting-started/building",id:"getting-started/building",isDocsHomePage:!1,title:"Building",description:"The fastest way to understand what this project is about is to run it. The following steps will instruct you how to build the main application along with the off-the-shelf modules.",source:"@site/docs/getting-started/building.md",sourceDirName:"getting-started",slug:"/getting-started/building",permalink:"/project-weekend-puzzles/docs/getting-started/building",editUrl:"https://github.com/NikodemMazur/project-weekend-puzzles/edit/master/website/docs/getting-started/building.md",version:"current",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"tutorialSidebar",previous:{title:"Preparing environment",permalink:"/project-weekend-puzzles/docs/getting-started/env"},next:{title:"Creating module",permalink:"/project-weekend-puzzles/docs/getting-started/creating-module"}},d=[{value:"Checkout the repository",id:"checkout-the-repository",children:[]},{value:"Build the app and referenced modules",id:"build-the-app-and-referenced-modules",children:[]},{value:"Control modules through LINQPad 5",id:"control-modules-through-linqpad-5",children:[]}],s={toc:d};function p(e){var t=e.components,n=(0,o.Z)(e,a);return(0,i.kt)("wrapper",(0,r.Z)({},s,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("p",null,"The fastest way to understand what this project is about is to run it. The following steps will instruct you how to build the main application along with the off-the-shelf modules."),(0,i.kt)("h2",{id:"checkout-the-repository"},"Checkout the repository"),(0,i.kt)("pre",null,(0,i.kt)("code",{parentName:"pre",className:"language-powershell"},"cd <your-repo-folder>\ngit clone https://github.com/NikodemMazur/project-weekend-puzzles.git\n")),(0,i.kt)("h2",{id:"build-the-app-and-referenced-modules"},"Build the app and referenced modules"),(0,i.kt)("p",null,"To run the application with all modules loaded, one should build the ",(0,i.kt)("em",{parentName:"p"},"app")," solution first. The solution output are ",(0,i.kt)("em",{parentName:"p"},"ProjectWeekendPuzzles.exe")," and ",(0,i.kt)("em",{parentName:"p"},"ProjectWeekendPuzzles.Core.dll"),"; the latter is needed prior to building modules since it is the main dependency of the entire project. At this point, the output executable ",(0,i.kt)("em",{parentName:"p"},"ProjectWeekendPuzzles.exe")," would be runnable if ",(0,i.kt)("em",{parentName:"p"},"ProjectWeekendPuzzles.dll.config")," had not told it to search for ",(0,i.kt)("em",{parentName:"p"},"dashboard")," and ",(0,i.kt)("em",{parentName:"p"},"module-info")," modules. Therefore, before running the executable, one needs to visit the module solutions and build them. Once it is done, the executable should run without any errors."),(0,i.kt)("h2",{id:"control-modules-through-linqpad-5"},"Control modules through LINQPad 5"),(0,i.kt)("p",null,"The Project Weekend Puzzles is up and running. The ",(0,i.kt)("em",{parentName:"p"},"dashboard")," module can be controlled through its client. Run ",(0,i.kt)("inlineCode",{parentName:"p"},"<your-repo-folder>\\project-weekend-puzzles\\tests\\modules\\dashboard\\TestQuery.linq")," and see the ",(0,i.kt)("em",{parentName:"p"},"dashboard")," module view updated to what you send as a request."))}p.isMDXComponent=!0}}]);