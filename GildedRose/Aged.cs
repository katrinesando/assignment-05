namespace GildedRose{
    public class Aged : Item{
        public override void Update(){
            this.SellIn--;
            if(Quality < 50){
                this.Quality++;
                if (SellIn < 0 && Quality < 50){
                    this.Quality++;
            }   
            }
        }   
    }
}