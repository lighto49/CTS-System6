var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var roomId = document.getElementById("RoomId").value;
var status = document.getElementById("Status").value;


//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;



connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});


connection.start().then(function () {
    if (status) {
        document.getElementById("sendButton").disabled = false;
        connection.invoke("JoinRoom", roomId).catch(function (err) {
            return console.error(err.toString());
        });
    }
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message, roomId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


$('#sendButton').click(function () {
    var text = $('#messageInput').val();
    $.ajax({
        url: '/Chat/SaveMessage',
        data: { 'roomId': roomId, 'Text': text },
        type: "POST",
        //cache: false,
        success: function () {
            console.log("Done!");
        },
        error: function (err) {
            console.log(err);
        }
    });
});