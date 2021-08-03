"use strict";(self.webpackChunkwebsite=self.webpackChunkwebsite||[]).push([[653],{3905:function(e,t,n){n.d(t,{Zo:function(){return l},kt:function(){return m}});var r=n(7294);function o(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function i(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function a(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?i(Object(n),!0).forEach((function(t){o(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function c(e,t){if(null==e)return{};var n,r,o=function(e,t){if(null==e)return{};var n,r,o={},i=Object.keys(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||(o[n]=e[n]);return o}(e,t);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);for(r=0;r<i.length;r++)n=i[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(o[n]=e[n])}return o}var s=r.createContext({}),u=function(e){var t=r.useContext(s),n=t;return e&&(n="function"==typeof e?e(t):a(a({},t),e)),n},l=function(e){var t=u(e.components);return r.createElement(s.Provider,{value:t},e.children)},p={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},d=r.forwardRef((function(e,t){var n=e.components,o=e.mdxType,i=e.originalType,s=e.parentName,l=c(e,["components","mdxType","originalType","parentName"]),d=u(n),m=o,f=d["".concat(s,".").concat(m)]||d[m]||p[m]||i;return n?r.createElement(f,a(a({ref:t},l),{},{components:n})):r.createElement(f,a({ref:t},l))}));function m(e,t){var n=arguments,o=t&&t.mdxType;if("string"==typeof e||o){var i=n.length,a=new Array(i);a[0]=d;var c={};for(var s in t)hasOwnProperty.call(t,s)&&(c[s]=t[s]);c.originalType=e,c.mdxType="string"==typeof e?e:o,a[1]=c;for(var u=2;u<i;u++)a[u]=n[u];return r.createElement.apply(null,a)}return r.createElement.apply(null,n)}d.displayName="MDXCreateElement"},3919:function(e,t,n){function r(e){return!0===/^(\w*:|\/\/)/.test(e)}function o(e){return void 0!==e&&!r(e)}n.d(t,{b:function(){return r},Z:function(){return o}})},4996:function(e,t,n){n.d(t,{C:function(){return i},Z:function(){return a}});var r=n(2263),o=n(3919);function i(){var e=(0,r.default)().siteConfig,t=(e=void 0===e?{}:e).baseUrl,n=void 0===t?"/":t,i=e.url;return{withBaseUrl:function(e,t){return function(e,t,n,r){var i=void 0===r?{}:r,a=i.forcePrependBaseUrl,c=void 0!==a&&a,s=i.absolute,u=void 0!==s&&s;if(!n)return n;if(n.startsWith("#"))return n;if((0,o.b)(n))return n;if(c)return t+n;var l=n.startsWith(t)?n:t+n.replace(/^\//,"");return u?e+l:l}(i,n,e,t)}}}function a(e,t){return void 0===t&&(t={}),(0,i().withBaseUrl)(e,t)}},2924:function(e,t,n){var r=n(7294).createContext(void 0);t.Z=r},8465:function(e,t,n){n.d(t,{Z:function(){return p}});var r=n(7462),o=n(3366),i=n(7294),a=n(6010),c=n(2263),s=n(5350),u={themedImage:"themedImage_1VuW","themedImage--light":"themedImage--light_3UqQ","themedImage--dark":"themedImage--dark_hz6m"},l=["sources","className","alt"],p=function(e){var t=(0,c.default)().isClient,n=(0,s.Z)().isDarkTheme,p=e.sources,d=e.className,m=e.alt,f=void 0===m?"":m,h=(0,o.Z)(e,l),g=t?n?["dark"]:["light"]:["light","dark"];return i.createElement(i.Fragment,null,g.map((function(e){return i.createElement("img",(0,r.Z)({key:e,src:p[e],alt:f,className:(0,a.Z)(u.themedImage,u["themedImage--"+e],d)},h))})))}},5350:function(e,t,n){var r=n(7294),o=n(2924);t.Z=function(){var e=(0,r.useContext)(o.Z);if(null==e)throw new Error("`useThemeContext` is used outside of `Layout` Component. See https://docusaurus.io/docs/api/themes/configuration#usethemecontext.");return e}},2938:function(e,t,n){n.r(t),n.d(t,{frontMatter:function(){return u},metadata:function(){return l},toc:function(){return p},default:function(){return m}});var r=n(7462),o=n(3366),i=(n(7294),n(3905)),a=n(8465),c=n(4996),s=["components"],u={sidebar_position:2},l={unversionedId:"concepts/tech-independence",id:"concepts/tech-independence",isDocsHomePage:!1,title:"Tech independence",description:"The model's technology independence has been attained with gRPC Web Server. The server hosts gRPC services that listen to modules' gRPC clients. Every gRPC service is coupled to only one Prism module. In this way, modules are controlled separately by a client that they provide. At this point, one should notice the important requirement that all modules have to be initialized prior to running the gRPC Server. It suggests that the view authorization should take place as late as after the Prism's initialization process.",source:"@site/docs/concepts/tech-independence.md",sourceDirName:"concepts",slug:"/concepts/tech-independence",permalink:"/project-weekend-puzzles/docs/concepts/tech-independence",editUrl:"https://github.com/NikodemMazur/project-weekend-puzzles/edit/master/website/docs/concepts/tech-independence.md",version:"current",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"tutorialSidebar",previous:{title:"Modularity",permalink:"/project-weekend-puzzles/docs/concepts/modularity"},next:{title:"View authorization",permalink:"/project-weekend-puzzles/docs/concepts/view-auth"}},p=[],d={toc:p};function m(e){var t=e.components,n=(0,o.Z)(e,s);return(0,i.kt)("wrapper",(0,r.Z)({},d,n,{components:t,mdxType:"MDXLayout"}),(0,i.kt)("p",null,"The ",(0,i.kt)("strong",{parentName:"p"},"model's technology independence")," has been attained with ",(0,i.kt)("em",{parentName:"p"},"gRPC Web Server"),". The server hosts ",(0,i.kt)("em",{parentName:"p"},"gRPC services")," that listen to modules' ",(0,i.kt)("em",{parentName:"p"},"gRPC clients"),". Every ",(0,i.kt)("em",{parentName:"p"},"gRPC service")," is coupled to only one ",(0,i.kt)("em",{parentName:"p"},"Prism")," module. In this way, modules are controlled separately by a client that they provide. At this point, one should notice the important requirement that all modules have to be initialized prior to running the ",(0,i.kt)("em",{parentName:"p"},"gRPC Server"),". It suggests that the view authorization should take place as late as after the ",(0,i.kt)("em",{parentName:"p"},"Prism's")," initialization process."),(0,i.kt)(a.Z,{align:"left",width:"800",alt:"IPC",sources:{light:(0,c.Z)("/img/ipc_light.svg"),dark:(0,c.Z)("/img/ipc_dark.svg")},mdxType:"ThemedImage"}))}m.isMDXComponent=!0},6010:function(e,t,n){function r(e){var t,n,o="";if("string"==typeof e||"number"==typeof e)o+=e;else if("object"==typeof e)if(Array.isArray(e))for(t=0;t<e.length;t++)e[t]&&(n=r(e[t]))&&(o&&(o+=" "),o+=n);else for(t in e)e[t]&&(o&&(o+=" "),o+=t);return o}function o(){for(var e,t,n=0,o="";n<arguments.length;)(e=arguments[n++])&&(t=r(e))&&(o&&(o+=" "),o+=t);return o}n.d(t,{Z:function(){return o}})}}]);