package be.pxl.backend.repositories;

import be.pxl.backend.models.Humidity;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
public interface HumidityRepository extends CrudRepository<Humidity, Integer> {

    List<Humidity> getHumidityForSessesion(int id);

}
