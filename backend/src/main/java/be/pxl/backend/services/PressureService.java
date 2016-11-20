package be.pxl.backend.services;

import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.models.Pressure;
import be.pxl.backend.repositories.PressureRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * Created by Jonas on 14/10/16.
 */

@Service
public class PressureService {

    @Autowired
    private JmsSender jmsSender;

    @Autowired
    private PressureRepository pressureRepository;

    public Pressure addPressure(Pressure pressure) {
        pressure = pressureRepository.save(pressure);
        jmsSender.sendMessage("add pressure with id:" + pressure.getId());
        return pressure;
    }

    public List<Pressure> getPressuresForSession(int id) {
        List<Pressure> pressures = pressureRepository.getPressuresForSession(id);
        jmsSender.sendMessage("get pressures for session id:" + id);
        return pressures;
    }
}
