package be.pxl.backend.services;

import be.pxl.backend.exceptions.AcceleroMeterException;
import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.repositories.AcceleroMeterRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * Created by Jonas on 14/10/16.
 */
@Service
public class AcceleroMeterService {

    @Autowired
    private JmsSender jmsSender;

    @Autowired
    private AcceleroMeterRepository acceleroMeterRepository;

    public AcceleroMeter addAcceleroMeter(AcceleroMeter acceleroMeter) {
        if (valueInRange(acceleroMeter.getX()) && valueInRange(acceleroMeter.getY()) && valueInRange(acceleroMeter.getZ())) {
            acceleroMeter = acceleroMeterRepository.save(acceleroMeter);
            jmsSender.sendMessage("add acceleroMeter with id:" + acceleroMeter.getId());
            return acceleroMeter;
        } else {
            AcceleroMeterException acceleroMeterException = new AcceleroMeterException();
            jmsSender.sendMessage("add acceleroMeter:" + acceleroMeterException.getMessage());
            throw acceleroMeterException;
        }
    }

    public List<AcceleroMeter> getAcceleroMetersForSession(int id) {
        List<AcceleroMeter> acceleroMeters = acceleroMeterRepository.getAcceleroMetersForSession(id);
        jmsSender.sendMessage("get acceleroMeters for session id:" + id);
        return acceleroMeters;
    }

    private boolean valueInRange(float value) {
        return (value >= 0 && value <= 250);
    }

}
