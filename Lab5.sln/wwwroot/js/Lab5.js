function calculateSum() {
    var input1 = parseFloat(document.getElementById('num1').value);
    var input2 = parseFloat(document.getElementById('num2').value);
    var sum = input1 + input2;
    document.getElementById('sum').innerText = 'The sum of ' + input1 + ' and ' + input2 + ' is : ' + sum;
    var resultDiv = document.getElementById('result');
    if (resultDiv.style.display === "none") {
        resultDiv.style.display = "block";
    } else {
        resultDiv.style.display = "none";
    }
}
