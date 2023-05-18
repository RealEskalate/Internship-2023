import 'package:equatable/equatable.dart';

abstract class ArticleEvent extends Equatable {
  const ArticleEvent();
}

class GetArticleEvent extends ArticleEvent {
  final String articleId;

  GetArticleEvent({required this.articleId});

  @override
  List<Object> get props => [articleId];
}