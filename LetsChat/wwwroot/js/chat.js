"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub")
    .configureLogging(signalR.LogLevel.Information).build();
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("recieveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " ;
    var message = msg;
    var li = document.createElement("div");
    
    var p1 = document.createElement("p");
    li.append(p1);
    p1.textContent = encodedMsg;
    var p = document.createElement("p");
    li.append(p);
    p.textContent = msg;
    li.className = "jumbotron text-right chattextother"
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    console.log("connected");
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    debugger;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    //event.preventDefault();
});