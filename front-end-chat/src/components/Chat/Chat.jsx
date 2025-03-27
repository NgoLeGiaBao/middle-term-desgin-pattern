import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import './Chat.css';

const Chat = () => {
    const [messages, setMessages] = useState([]);
    const [inputMessage, setInputMessage] = useState('');
    const [username, setUsername] = useState('');
    const [isConnected, setIsConnected] = useState(false);
    const messagesEndRef = useRef(null);

    useEffect(() => {
        fetchMessageHistory();
        const interval = setInterval(fetchMessageHistory, 20000);
        return () => clearInterval(interval);
    }, []);

    useEffect(() => {
        scrollToBottom();
    }, [messages]);

    const fetchMessageHistory = async () => {
        try {
            const response = await axios.get('/demo-chat/history');
            setMessages(response.data);
        } catch (error) {
            console.error('Error fetching message history:', error);
        }
    };

    const scrollToBottom = () => {
        messagesEndRef.current?.scrollIntoView({ behavior: 'smooth' });
    };

    const handleSendMessage = async (isBroadcast = false) => {
        if (!inputMessage.trim() || !username.trim()) return;

        try {
            const endpoint = isBroadcast ? '/demo-chat/broadcast' : '/demo-chat/send';
            await axios.post(endpoint, {
                SenderName: username,
                Message: inputMessage
            });
            setInputMessage('');
        } catch (error) {
            console.error('Error sending message:', error);
        }
    };

    const handleUndoLastMessage = async () => {
        try {
            await axios.post('/demo-chat/undo');
        } catch (error) {
            console.error('Error undoing message:', error);
        }
    };

    const handleConnect = () => {
        if (username.trim()) {
            setIsConnected(true);
        }
    };

    return (
        <div className="chat-container">
            <h1>Chat Application</h1>
            
            {!isConnected ? (
                <div className="connect-form">
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        placeholder="Enter your username"
                    />
                    <button onClick={handleConnect}>Connect</button>
                </div>
            ) : (
                <>
                    <div className="messages-container">
                        {messages.map((msg, index) => (
                            <div key={index} className="message">
                                {msg}
                            </div>
                        ))}
                        <div ref={messagesEndRef} />
                    </div>
                    
                    <div className="input-area">
                        <input
                            type="text"
                            value={inputMessage}
                            onChange={(e) => setInputMessage(e.target.value)}
                            placeholder="Type your message..."
                            onKeyPress={(e) => e.key === 'Enter' && handleSendMessage()}
                        />
                        
                        <div className="button-group">
                            <button onClick={() => handleSendMessage()}>Send</button>
                            <button onClick={() => handleSendMessage(true)}>Broadcast</button>
                            <button onClick={handleUndoLastMessage} className="undo-button">
                                Undo Last
                            </button>
                        </div>
                    </div>
                </>
            )}
        </div>
    );
};

export default Chat;