"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

var count = 0;
connection.on("ReceiveMessage", function (user, message) {
    count++;
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + ": " + msg;
    var para = document.createElement("P");
    para.innerText = encodedMsg;
    if (count === 20) {
        while (count > 5) {
            var list = document.getElementById("messagesList");
            list.removeChild(list.childNodes[0]);
            count--;
        }
    }
    document.getElementById("messagesList").appendChild(para);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});