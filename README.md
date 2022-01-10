# kmeans-GeneticAlgorithm
I'm trying to cluster the trash cans and then assign garbage trucks to the clusters. Also, I will define the most suitable way for the truck while collecting the garbage.


the picture of garbage bin placeses.

![image](https://user-images.githubusercontent.com/63093864/148657542-99beab10-5ea6-4e0d-ad27-fea5f2854d27.png)

kmeans clusters

![image](https://user-images.githubusercontent.com/63093864/148657641-57a18e46-eaa9-4080-8a00-bddd3c1781bb.png)


try this: calculate avg distance btw points, make maximum radius is 2 or 3 times more then this value, so centeroid only included with nearby points, then if any point without a cluster. Assign points to nearest cluster

if cluster member counts differences are more than something, exclude from the furtest elements by half of the difference count. calculate the centoreids again, cluster it and start from the if any member without cluster...



# Resources
Thanks for support

Kmeans -> https://visualstudiomagazine.com/articles/2013/12/01/k-means-data-clustering-using-c.aspx?m=2

2d-plot-draw -> https://www.desmos.com/calculator
