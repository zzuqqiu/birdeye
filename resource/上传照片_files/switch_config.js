// 全站需要降级处理的一些配置项
var CMSSwitchs = {
    // 好友服务
    friendService: {
        add: true,
        remove: true,
        modify: true,
        search: true
    },

    // 评论服务
    commentService: {
        add: true,
        remove: true,
        modify: true,
        search: true
    },
//检索服务
search: true,

    // 图片广场服务
    plazaService: true
};


var xcGlobalConfig = {
	bubble: {
		enable: false,
		adjustLeft: 72,
		adjustTop: -5,
		angleAdjustLeft: 10,
		sign: '20130514', 
		content: '私密分享你的出游、聚会、兴趣美图',
		title: '图片共享使用百度群相册！',
		expires: 15,
		flagHideClose: false,  //true表示隐藏，false表示不隐藏
		link: '',
		linkName: '点击看答案',
		imgSrc: 'http://h.hiphotos.baidu.com/album/w%3D1600%3Bq%3D90/sign=a902d3407dd98d1076d40837110f837f/024f78f0f736afc3feee7ad9b219ebc4b64512af.jpg',
		theme: 'white',
		width: 248,
		selector: '#topnav .nav-item:nth(3)'
	}
};
if (location.href.indexOf('xiangce.baidu.com/1') >= 0){
xcGlobalConfig.bubble.enable = false;
}
/**
 * 关闭广场页面，by 先烈
 */
var closePlazaPage = function (plazaSwitch) {
 
    // 如果开关是关闭状态，就不管了
    if (plazaSwitch) return;
 
    // 隐藏顶部通栏的“图片广场”tab
    try {
        if (/^\/plaza/.test(location.pathname)) {
            location.href = '/';
        } else {
            $(function () {
                $('#topnav li a[href$="plaza"]').hide();
            });
        }
    } catch (err) {}
};

closePlazaPage(CMSSwitchs.plazaService);

$.cookie('xcsearchhint', '1');

/* 检索热搜词配置 */
var hotwords =[
    "美女"
    ,"风景"
    ,"猫"
    ,"宠物"
    ,"美食"
    ,"柳岩"
    ,"可爱"
    ,"火影忍者"
    ,"龙猫"
    ,"哈士奇"
    ,"写真"
   ];