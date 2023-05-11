import 'package:equatable/equatable.dart';

class Article extends Equatable {
  final String id;
  final String title;
  final String subtitle;
  final String description;
  final String postedBy;
  final DateTime publishedDate;
  final Enum tag;
  final String imageUrl;
  final int likeCount;
  final int timeEstimate;

  Article({
    required this.id,
    required this.title,
    required this.subtitle,
    required this.description,
    required this.postedBy,
    required this.publishedDate,
    required this.tag,
    required this.imageUrl,
    required this.likeCount,
    required this.timeEstimate,
  }) : super();

    @override
    List<Object> get props => [id, title, subtitle];
}