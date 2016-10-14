package be.pxl.backend.services;

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
    private PressureRepository pressureRepository;

    public Pressure addPressure(Pressure pressure) {
        return pressureRepository.save(pressure);
    }

    public List<Pressure> getPressuresForSession(int id) {
        return pressureRepository.getPressuresForSession(id);
    }
}
