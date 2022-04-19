let whiteMode = localStorage.getItem("whiteMode");
//const checkbox = document.querySelector("#checkbox");
const checkbox = document.getElementById('checkbox');
const bodyNodeList = document.body.childNodes;
const all_headings = document.querySelectorAll("h1, h2, h3, h4, h5, h6");
const all_spans = document.querySelectorAll("span");
const all_a = document.querySelectorAll("a");

const enableWhiteMode = () => {
    for (var i = 0; i < bodyNodeList.length; i++) {
        if (bodyNodeList[i].tagName == "DIV") {
            bodyNodeList[i].classList.add('white');
        }
    }

    for (var i = 0; i < all_spans.length; i++) {
        all_spans[i].classList.add('spanWhiteMode');
    }

    for (var i = 0; i < all_a.length; i++) {
        all_a[i].classList.add('aWhiteMode');
    }

    for (var i = 0; i < all_headings.length; i++) {
        all_headings[i].classList.add('headingss');
    }

    localStorage.setItem('whiteMode', 'enabled');

}

const disableWhiteMode = () => {
    for (var i = 0; i < bodyNodeList.length; i++) {
        if (bodyNodeList[i].tagName == "DIV") {
            bodyNodeList[i].classList.remove('white');
        }
    }

    for (var i = 0; i < all_spans.length; i++) {
        all_spans[i].classList.remove('spanWhiteMode');
    }

    for (var i = 0; i < all_a.length; i++) {
        all_a[i].classList.remove('aWhiteMode');
    }

    for (var i = 0; i < all_headings.length; i++) {
        all_headings[i].classList.remove('headingss');
    }

    localStorage.setItem('whiteMode', null);

}

if (whiteMode === 'enabled') {
    enableWhiteMode();
}

checkbox.addEventListener('click', () => {

    whiteMode = localStorage.getItem("whiteMode");

    if (whiteMode !== 'enabled') {
        enableWhiteMode();
        console.log(whiteMode);
    } else {
        disableWhiteMode();
        console.log(whiteMode);
    }
})