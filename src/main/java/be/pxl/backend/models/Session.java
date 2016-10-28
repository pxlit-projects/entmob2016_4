package be.pxl.backend.models;

import com.fasterxml.jackson.annotation.*;
import javax.persistence.*;
import javax.persistence.Entity;
import java.io.Serializable;
import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Entity
@Table(name = "Sessions")
public class Session implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    @Temporal(TemporalType.TIMESTAMP)
    private Date start;

    @Temporal(TemporalType.TIMESTAMP)
    private Date end;

    @JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
    @JsonIdentityReference(alwaysAsId = true)
    @JsonBackReference
    @ManyToOne
    @JoinColumn(name = "userId")
    private User user;

    @JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
    @JsonIdentityReference(alwaysAsId = true)
    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Temperature> temperatures;

    @JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
    @JsonIdentityReference(alwaysAsId = true)
    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Pressure> pressures;

    @JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
    @JsonIdentityReference(alwaysAsId = true)
    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<Humidity> humidities;

    @JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
    @JsonIdentityReference(alwaysAsId = true)
    @JsonManagedReference
    @OneToMany(mappedBy = "session")
    private List<AcceleroMeter> acceleroMeters;

    public int getId() {
        return id;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Date getStart() {
        return start;
    }

    public void setStart(Date start) {
        this.start = start;
    }

    public Date getEnd() {
        return end;
    }

    public void setEnd(Date end) {
        this.end = end;
    }

    public List<Temperature> getTemperatures() {
        return temperatures;
    }

    public void setTemperatures(List<Temperature> temperatures) {
        this.temperatures = temperatures;
    }

    public List<Pressure> getPressures() {
        return pressures;
    }

    public void setPressures(List<Pressure> pressures) {
        this.pressures = pressures;
    }

    public List<Humidity> getHumidities() {
        return humidities;
    }

    public void setHumidities(List<Humidity> humidities) {
        this.humidities = humidities;
    }

    public List<AcceleroMeter> getAcceleroMeters() {
        return acceleroMeters;
    }

    public void setAcceleroMeters(List<AcceleroMeter> acceleroMeters) {
        this.acceleroMeters = acceleroMeters;
    }
}
