import 'package:dark_knights/features/article/domain/usecases/get_article_by_id.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:dartz/dartz.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/article/domain/entities/article.dart';
import 'package:dark_knights/features/feeds/domain/usecases/get_articles.dart';
import 'package:dark_knights/features/feeds/domain/usecases/filter_articles.dart';
import 'package:dark_knights/features/feeds/domain/usecases/search_articles.dart';
import 'package:equatable/equatable.dart';

import '../../../../core/usecases/usecase.dart';

part 'feed_event.dart';
part 'feed_state.dart';

class FeedBloc extends Bloc<FeedEvent, FeedState> {
 final GetArticles _getArticles;
 final SearchArticles _searchArticles;
 final FilterArticles _filterArticles;
 final GetArticleById _getArticleById;

 FeedBloc(
 this._getArticles,
 this._searchArticles,
 this._filterArticles,
 this._getArticleById,
 ) : super(FeedLoading()) {
 on<FetchArticles>(_mapFetchArticlesToState);
 on<SearchArticlesEvent>(_mapSearchArticlesToState);
 on<FilterArticlesEvent>(_mapFilterArticlesToState);
 on<LoadArticleEvent>(_mapLoadArticleToState);
 }

 void _mapFetchArticlesToState(
 FetchArticles event, Emitter<FeedState> emit) async {
 emit(FeedLoading());
 final result = await _getArticles(NoParams());
 emit(_articlesSuccessOrFailure(result));
 }

 void _mapSearchArticlesToState(
 SearchArticlesEvent event, Emitter<FeedState> emit) async {
 emit(FeedLoading());
 final result = await _searchArticles(event.query);
 emit(_articlesSuccessOrFailure(result));
 }

 void _mapFilterArticlesToState(
 FilterArticlesEvent event, Emitter<FeedState> emit) async {
 emit(FeedLoading());
 final result = await _filterArticles(event.category);
 emit(_articlesSuccessOrFailure(result));
 }

 void _mapLoadArticleToState(
 LoadArticleEvent event, Emitter<FeedState> emit) async {
 emit(FeedLoading());
 final result = await _getArticleById(event.id);
 emit(result.fold(
 (failure) => FeedError(failure),
 (article) => ArticleLoaded(article),
 ));
 }

 FeedState _articlesSuccessOrFailure(Either<Failure, List<Article>> data) {
 return data.fold(
 (failure) => FeedError(failure),
 (articles) => FeedLoaded(articles),
 );
 }
}
