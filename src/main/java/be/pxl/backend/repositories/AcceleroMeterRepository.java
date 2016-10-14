package be.pxl.backend.repositories;

import be.pxl.backend.models.AcceleroMeter;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
public interface AcceleroMeterRepository extends CrudRepository<AcceleroMeter, Integer> {

    List<AcceleroMeter> getAcceleroMetersForSession(int id);

}
