package be.pxl.backend.jms;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

/**
 * Created by Jonas on 28/10/16.
 */

@Component
public class JmsSender {

    @Autowired
    private JmsTemplate jmsTemplate;

    public void sendMessage(String text) {
        jmsTemplate.send("LogQueue", s -> s.createTextMessage(text));
    }

}
