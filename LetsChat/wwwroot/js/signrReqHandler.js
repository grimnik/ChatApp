var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Channels/Chat').build();

connection.on('recieveMessage', addMessageToChat);

connection.start().catch(error => {
    console.error(error.message);
});

function sendMessageToHub(message) {
    connection.invoke('sendMessage',message)
}