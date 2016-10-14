package be.pxl.backend.repositories;

import be.pxl.backend.models.Temperature;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

public interface TemperatureRepository extends CrudRepository<Temperature, Integer> {

    List<Temperature> getTemperaturesForSession(int id);

}
