package be.pxl.backend.jms;

import org.apache.activemq.Message;
import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Service;

import javax.jms.JMSException;
import javax.jms.TextMessage;
import java.sql.Time;
import java.util.Date;

/**
 * Created by Jonas on 28/10/16.
 */

@Service
public class JmsReceiver {

    @JmsListener(destination = "LogQueue")
    public void onMessage(Message msg) {
        try {
            if(msg instanceof TextMessage) {
                String text = ((TextMessage)msg).getText();
                System.out.println(new Date() + ":" + text);
            }
        } catch (JMSException ex) {
            ex.printStackTrace();
        }
    }
}
