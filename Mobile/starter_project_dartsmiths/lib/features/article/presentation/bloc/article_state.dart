part of 'article_bloc.dart';

abstract class ArticleState extends Equatable {
  const ArticleState();
  
  @override
  List<Object> get props => [];
}

class ArticleInitial extends ArticleState {}

class ArticleLoading extends ArticleState {}

class ArticleSuccess extends ArticleState {

  final Article article ;

  ArticleSuccess({required this.article});

  @override
  List<Object> get props => [article];
}


class ArticleFailure extends ArticleState{
  final Error error ;

  ArticleFailure({required this.error});

  @override
  List<Object> get props => [error];
}