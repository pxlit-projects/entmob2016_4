package be.pxl.backend.repositories;

import be.pxl.backend.models.Humidity;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository
public interface HumidityRepository extends CrudRepository<Humidity, Integer> {

    @Query(value = "select h from Humidity h where h.session.id =:id")
    List<Humidity> getHumidityForSession(@Param(value = "id") int id);

    @Modifying
    @Query(value = "delete from Humidity h where h.session.id =:id")
    void deleteForSession(@Param(value = "id") int id);
}
