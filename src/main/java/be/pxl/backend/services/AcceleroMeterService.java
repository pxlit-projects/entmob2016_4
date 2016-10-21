package be.pxl.backend.services;

import be.pxl.backend.exceptions.AcceleroMeterException;
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
    private AcceleroMeterRepository acceleroMeterRepository;

    public AcceleroMeter addAcceleroMeter(AcceleroMeter acceleroMeter) {
        if (valueInRange(acceleroMeter.getX()) && valueInRange(acceleroMeter.getY()) && valueInRange(acceleroMeter.getZ())) {
            return acceleroMeterRepository.save(acceleroMeter);
        } else {
            throw new AcceleroMeterException();
        }

    }

    public List<AcceleroMeter> getAcceleroMetersForSession(int id) {
        return acceleroMeterRepository.getAcceleroMetersForSession(id);
    }

    private boolean valueInRange(float value) {
        return (value >= 0 && value <= 250);
    }

}
