import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

class Article extends Equatable {
  final String id;
  final String title;
  final String subTitle;
  final String content;
  final List<String> tags;
  final String authorId;

  Article(
      {required this.id,
      required this.title,
      required this.subTitle,
      required this.content,
      required this.tags,
      required this.authorId
      });

  @override
  List<Object> get props => [id, title, subTitle, content, tags, authorId];
  
}
