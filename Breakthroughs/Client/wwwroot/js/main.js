function nSelected(selected, previous) {
    var selectElem = document.getElementById(selected)
    var deselectElem = document.getElementById(previous)
    
    deselectElem.className = "list"
    selectElem.className = "list list-selected"
}
