import '../../domain/entities/article.dart';

class ArticleModel extends Article{
  ArticleModel({
    required String id, 
    required String title, 
    required String subtitle, 
    required String description, 
    required String postedBy, 
    required DateTime publishedDate, 
    required Enum tag, 
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
    timeEstimate: timeEstimate
  );

}