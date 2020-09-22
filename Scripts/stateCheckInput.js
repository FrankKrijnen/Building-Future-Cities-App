
function stateCheckInput() {
   
    var textinputs = document.querySelectorAll('input[type=radio]');

    for (var i = 0; i < textinputs.length; i++) {
        if (textinputs[i].checked == true) {
            textinputs[i].parentElement.parentElement.classList.add("table-cell-selected");
           
        }
        if (textinputs[i].checked == false) {
            textinputs[i].parentElement.parentElement.classList.remove("table-cell-selected");

        }
        
    }


}