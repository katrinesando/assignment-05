namespace GildedRose{
    
    public class BackstagePass : Item{

        public override void Update(){
            this.SellIn--;
            if(this.SellIn > 10 && this.Quality < 50){
                Quality = Math.Clamp(Quality+1,0,50);
            }
            if(this.SellIn > 5 && this.SellIn <= 10 && this.Quality < 50){
                Quality = Math.Clamp(Quality+2,0,50);            
            }
            if(this.SellIn > 0 && this.SellIn <= 5 && this.Quality < 50){
                Quality = Math.Clamp(Quality+3,0,50);            
            }
            if (this.SellIn < 0){
                this.Quality = 0;
            }
        }
    }
}