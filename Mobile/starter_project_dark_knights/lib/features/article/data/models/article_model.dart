import '../../domain/entities/article.dart';

class ArticleModel extends Article {
  ArticleModel({
    required String id,
    required String title,
    required String subtitle,
    required String description,
    required String postedBy,
    required DateTime publishedDate,
    required String tag,
    required String imageUrl,
    required int likeCount,
    required int timeEstimate,
  }) : super(
          id: id,
          title: title,
          subtitle: subtitle,
          description: description,
          postedBy: postedBy,
          publishedDate: publishedDate,
          tag: tag,
          imageUrl: imageUrl,
          likeCount: likeCount,
          timeEstimate: timeEstimate,
        );

  factory ArticleModel.fromJson(Map<String, dynamic> json) {

    return ArticleModel(
      id: json['id'],
      title: json['title'],
      subtitle: json['subtitle'],
      description: json['description'],
      postedBy: json['postedBy'],
      publishedDate: DateTime.parse(json['publishedDate']),
      tag: json['tag'],
      imageUrl: json['imageUrl'],
      likeCount: json['likeCount'],
      timeEstimate: (json['timeEstimate'] as num).toInt(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'id' : id, 
      'title' : title, 
      "subtitle": subtitle,
      "description": description, 
      "postedBy" : postedBy,
      "publishedDate" : publishedDate.toIso8601String().split(".")[0], 
      "tag": tag, 
      "imageUrl":imageUrl, 
      "likeCount":likeCount, 
      "timeEstimate" :timeEstimate
    };
  }
}
