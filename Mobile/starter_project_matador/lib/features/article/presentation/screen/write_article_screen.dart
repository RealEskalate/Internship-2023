import 'package:flutter/material.dart';
import '../widgets/article_title.dart';
import '../widgets/add_many_tags.dart';
import '../widgets/content_widget.dart';
import '../widgets/publish_button.dart';
import '../widgets/subtitle_widget.dart';
import '../widgets/tags_widget.dart';
import '../widgets/title_widget.dart';

class WriteArticlePage extends StatelessWidget {
  const WriteArticlePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: IconButton(
          icon: const Icon(Icons.arrow_back, color: Colors.black),
          onPressed: () {},
        ),
        title: const ArticleTitle(),
        centerTitle: true,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              height: screenSize.height * 0.02,
            ),
            const TitleWidget(),
            const SubtitleWidget(),
            SizedBox(height: screenSize.height * 0.02),
            const TagsWidget(),
            SizedBox(height: screenSize.height * 0.01),
            const AddManyTags(),
            SizedBox(height: screenSize.height * 0.05),
            const ContentWidget(),
            SizedBox(height: screenSize.height * 0.05),
            const PublishButton(),
          ],
        ),
      ),
    );
  }
}