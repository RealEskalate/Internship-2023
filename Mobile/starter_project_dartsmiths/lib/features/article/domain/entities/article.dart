import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

class Article {
  final String id;
  final String title;
  final String subTitle;
  final String content;
  final List<String> tags;

  Article({
    required this.id,
    
    required this.title,
    required this.subTitle,
    required this.content,
    required this.tags
  });

   @override
  List<Object> get props => [id, title, subTitle, content, tags ];

}