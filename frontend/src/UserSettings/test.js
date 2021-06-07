
var questionIndex  = document.querySelectorAll(".card-body .question").length;



function removeFadeOut(el, speed) {
    var seconds = speed / 1000;
    el.style.transition = "opacity " + seconds + "s ease";
    el.style.opacity = 0;
    setTimeout(function () {
        el.parentNode.removeChild(el);
    }, speed);

}


function addOption(id) {
    var question = document.querySelectorAll(".card-body .question")[id]; //Get the question by id
    var optionid = question.getElementsByClassName("col-lg-6 question-option").length // get the index for the next option
    var option = ` <div class="col-lg-6 question-option">
                                <input type="text" name="Sections[0].Questions[${id}].Options[${optionid}].OptionText" class="form-control" placeholder="Enter Option" />
                                <span class="form-text text-muted">Option Is Required</span>
                            <button type="button" onclick="deleteOption(${id},${optionid})" class="btn btn-danger deleteOptionButton">Delete Option</button>
                                <br />
                            </div>`;
    question.insertAdjacentHTML("beforeend", option); //insert option to question
}

function addQuestion(id) {
    var type = document.getElementsByClassName("selectType")[0].value; //We get the value for the selected type of question
    var question = getType(type); //We get the html code of that type of question
    var section = document.querySelectorAll(".SurveyPage .section")[id]; //We get the section where we want to add the question (In this case we have only one survey)
    section.insertAdjacentHTML("beforeend", question);//We insert the question 
    questionIndex = questionIndex + 1;//We move the index by one for the next question to be added
}

function deleteQuestion(questionId) {
    var questions = document.querySelectorAll(".card-body .question"); // Get a list of all the questions in the form 
    removeFadeOut(questions[questionId], 500); //remove the the question with a fadeout effect

    resetIndexes();

}


function deleteOption(questionId, optionId) {
    var question = document.querySelectorAll(".card-body .question")[questionId];
    var options = question.getElementsByClassName("col-lg-6 question-option");
    removeFadeOut(options[optionId], 1000);

    var deleteOptionButton = question.querySelectorAll(".deleteOptionButton");
    if (deleteOptionButton.length > 0) {

        for (var k = 0; k < deleteOptionButton.length; k++) {
            deleteOptionButton[k].setAttribute("onClick", `deleteOption(${questionId},${k})`)
        }
    }

}

function resetIndexes() {
    var questionList = document.querySelectorAll(".card-body question");
    const regex = /(?<=name=\"Sections\[0]\.Questions\[)(.)(?=].)/gm; //Regex which selects all the questionIndex in Sections[0].Questions[questionindex].Description

    for (var i = 0; i < questionList.length; i++) {
        var thisquestion = questionList[i];
        var deleteButton = thisquestion.querySelectorAll(".deleteQuestionButton")[0];
        var optionbutton = thisquestion.querySelectorAll(".addQuestionOptionButton")[0];
        var input = thisquestion.querySelectorAll("input[type=text]");
        var deleteOptionButton = thisquestion.querySelectorAll(".deleteOptionButton")[0];
        var addOptionsButtons = thisquestion.querySelectorAll(".addQuestionOptionButton")[0];

        deleteButton.setAttribute("onClick", `deleteQuestion(${i})`);
        optionbutton.setAttribute("onClick", `addOption(${i})`);

        //Reset all the text fields with the current value
        for ( var j = 0; j < input.length; j++) {
            var tempinput = document.createElement("null");//Create an empty html element
            var oldinput = input[j].outerHTML; //Get html code from old output
            tempinput.innerHTML = oldinput.replace(regex, `${i}`); //Replace the empty element html code with the old element code after teplacing the index in section.question[index]
            tempinput = tempinput.firstChild; //Remove <null></null>
            tempinput.value = input[j].value;//Pass the value from old input to new one
            input[j].replaceWith(tempinput); //Remplace input
        }
        if (addOptionsButtons!=null) {
            addOptionsButtons[0].setAttribute("OnClick", `addOption(${i})`)
        }
        if (deleteOptionButton.length != null) {
            for (var k = 0; k < deleteOptionButton.length; k++) {
                deleteOptionButton[k].setAttribute("onClick", `deleteOption(${i},${k})`)
            }
        }
    
    }
    questionIndex = questionIndex - 1;
}
function getType(id) {
    var textFields = ` <div class="card-body question">
                        <h3 class="font-size-lg text-dark font-weight-bold mb-6"><span class="questionNumberTitle">${(questionIndex)}</span> Question</h3>
                        <div class="mb-15">
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Name</label>
                                <div class="col-lg-6">
                                    <input  name="Sections[0].Questions[${questionIndex}].QuestionText" type="text" class="form-control"  placeholder="Enter Question Name" />
                                    <span class="form-text text-muted">Question Is Required</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Description:</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].Description" type="text" class="form-control" placeholder="Enter Description" />
                                   <input name="Sections[0].Questions[${questionIndex}].InputId" type="hidden" value="1"/>

<span class="form-text text-muted">Description Is Not Required</span>
                                    <p style="color:red;">Type: Text</p>
                                    <br />
                                </div>
                            </div>
                            <button type="button" onclick="deleteQuestion(${(questionIndex)})" class="btn btn-danger deleteQuestionButton">Delete Question</button>

                        </div>`;
    var fileInput = ` <div class="card-body question">
                        <h3 class="font-size-lg text-dark font-weight-bold mb-6" ><span class="questionNumberTitle">${(questionIndex)}</span>. Question</h3>
                        <div class="mb-15">
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Name</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].QuestionText" type="text" class="form-control"   placeholder="Enter Question Name" />
                                    <span class="form-text text-muted">Question Is Required</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Description:</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].Description" type="text" class="form-control" placeholder="Enter Description" />
                                   <input name="Sections[0].Questions[${questionIndex}].InputId" type="hidden" value="3"/>
                                    
<span class="form-text text-muted">Description Is Not Required</span>
                                    <p style="color:red;">Type: File</p>
                                    <br />
                                </div>
                            </div>
                            <button type="button" onclick="deleteQuestion(${questionIndex})" class="btn btn-danger deleteQuestionButton">Delete Question</button>

                        </div>`;
    var YesNo = ` <div class="card-body question">
                        <h3 class="font-size-lg text-dark font-weight-bold mb-6"><span class="questionNumberTitle">${(questionIndex)}</span>. Question</h3>
                        <div class="mb-15">
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Name</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].QuestionText" type="text" class="form-control" name="Sections[0].Questions[${questionIndex}].QuestionText" placeholder="Enter Question Name" />
                                    <span class="form-text text-muted">Question Is Required</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Description:</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].Description" type="text" class="form-control" placeholder="Enter Description" />
                                                                       <input name="Sections[0].Questions[${questionIndex}].InputId" type="hidden" value="2"/>

<span class="form-text text-muted">Description Is Not Required</span>
                                    <p style="color:red;">Type: Yes/No</p>
                                    <br />
                                </div>
                            </div>
                            <button type="button" onclick="deleteQuestion(${questionIndex})" class="btn btn-danger deleteQuestionButton">Delete Question</button>

                        </div>`;
    var Select = ` <div class="card-body question">
                        <h3 class="font-size-lg text-dark font-weight-bold mb-6"><span class="questionNumberTitle">${(questionIndex)}</span>. Question</h3>
                        <div class="mb-15">
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Name</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].QuestionText" type="text" class="form-control" name="Sections[0].Questions[${questionIndex}].QuestionText" placeholder="Enter Question Name" />
                                    <span class="form-text text-muted">Question Is Required</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Description:</label>
                                <div class="col-lg-6">
                                    <input  name="Sections[0].Questions[${questionIndex}].Description" type="text" class="form-control" placeholder="Enter Description" />
                                   <input name="Sections[0].Questions[${questionIndex}].InputId" type="hidden" value="4"/>
                                    
<span class="form-text text-muted">Description Is Not Required</span>
                                    <p style="color:red;">Type: Select</p>
                                    <br />
                                </div>

                            </div>
                            <button type="button" onclick="addOption(${questionIndex})" class="btn btn-primary addQuestionOptionButton">Add Option</button>
                            <button type="button" onclick="deleteQuestion(${questionIndex})" class="btn btn-danger deleteQuestionButton">Delete Question</button>

                        </div>`;
    var multiSelect = ` <div class="card-body question">
                        <h3 class="font-size-lg text-dark font-weight-bold mb-6 "><span class="questionNumberTitle">${(questionIndex)}</span>. Question</h3>
                        <div class="mb-15">
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Name</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].QuestionText" type="text" class="form-control"  name="Sections[0].Questions[${questionIndex}].QuestionText" placeholder="Enter Question Name" />
                                   <input name="Sections[0].Questions[${questionIndex}].InputId" type="hidden" value="5"/>
                                    
<span class="form-text text-muted">Question Is Required</span>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 col-form-label text-right">Question Description:</label>
                                <div class="col-lg-6">
                                    <input name="Sections[0].Questions[${questionIndex}].Description"  type="text" class="form-control" placeholder="Enter Description" />
                                    <span class="form-text text-muted">Description Is Not Required</span>
                                    <p style="color:red;">Type: MultiSelect</p>
                                    <br />
                                </div>

                            </div>
                            <button type="button" onclick="deleteQuestion(${questionIndex})" class="btn btn-danger deleteQuestionButton">Delete Question</button>
                            <button type="button" onclick="addOption(${questionIndex})" class="btn btn-primary addQuestionOptionButton">Add Option</button>

                        </div>`;
    if (id == 1) {
        return textFields;
    } else if (id == 2) {
        return YesNo;
    } else if (id == 3) {
        return fileInput;
    } else if (id == 4) {
        return Select;
    } else if (id == 5) {
        return multiSelect;
    }

}