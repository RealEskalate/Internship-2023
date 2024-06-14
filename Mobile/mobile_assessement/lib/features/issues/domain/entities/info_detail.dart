import 'package:mobile_assessement/features/issues/data/model/info.dart';

class InfoDetail {
  String id;
  User userId;
  String classId;
  String title;
  String description;
  List<Archive> archives;
  List<String> tags;
  bool isFavorite;

  InfoDetail({
    required this.id,
    required this.userId,
    required this.classId,
    required this.title,
    required this.description,
    required this.archives,
    required this.tags,
    // required this.createdAt,
    // required this.updatedAt,
    required this.isFavorite,
  });
}

// class Archive {
//   String id;
//   String name;
//   String fileAddress;
//   String cloudinaryId;
//   // DateTime createdAt;
//   // DateTime updatedAt;

//   Archive({
//     required this.id,
//     required this.name,
//     required this.fileAddress,
//     required this.cloudinaryId,
//     // required this.createdAt,
//     // required this.updatedAt,
//   });
// }
