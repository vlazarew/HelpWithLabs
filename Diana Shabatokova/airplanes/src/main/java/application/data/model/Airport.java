package application.data.model;

import lombok.*;
import lombok.experimental.FieldDefaults;

import javax.persistence.*;
import java.time.LocalDate;
import java.time.LocalTime;

@Entity
@Data
@FieldDefaults(level = AccessLevel.PRIVATE)
@AllArgsConstructor
@NoArgsConstructor
@Table(indexes = {@Index(columnList = "name", name = "airport_name_index")})
@Getter
@Setter
public class Airport {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id;

//    @Column
//    LocalDate creationDate;
//    @Column
//    LocalTime creationTime;

    @Column(name = "name")
    String name;

    @Column(name = "short_name")
    String shortName;

    @JoinColumn(name ="city_id")
    @ManyToOne
    City city;
}
